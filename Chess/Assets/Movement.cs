using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public static class Movement
{
    private static int positionX;
    private static int positionY;
    private static CompileBoard.colors color;
    public static ArrayList moves = new ArrayList(); 

    public static void setVariables(int x, int y, CompileBoard.colors colors)
    {
        positionX = x;
        positionY = y;
        color = colors;
    }

    public static void check(int x, int y, CompileBoard.directions direction, CompileBoard.pieces pieces)
    {

        if (pieces == CompileBoard.pieces.CASTLE)
        {
            if (direction == CompileBoard.directions.DUPRIGHT)
                return;
        } else
        {
            if (direction == CompileBoard.directions.END)
                return;
        }

        switch (direction)
        {
            case CompileBoard.directions.UP:
                y++;
                break;
            case CompileBoard.directions.DOWN:
                y--;
                break;
            case CompileBoard.directions.LEFT:
                x--;
                break;
            case CompileBoard.directions.RIGHT:
                x++;
                break;
            case CompileBoard.directions.DUPRIGHT:
                y++; x++;
                break;
            case CompileBoard.directions.DUPLEFT:
                y++; x--;
                break;
            case CompileBoard.directions.DDOWNLEFT:
                y--; x--;
                break;
            case CompileBoard.directions.DDOWNRIGHT:
                y--; x++;
                break;
        }

        if ((x > 7 || x < 0) || (y > 7 || y < 0))
        {
            check(positionX, positionY, direction + 1, pieces);
        }
        else
        {

            if (CompileBoard.board[x, y].GetComponent<Item>().getColor() == CompileBoard.colors.NULL)
            {
                CompileBoard.board[x, y].GetComponent<Item>().showMove();

                moves.Add(CompileBoard.board[x, y].GetComponent<Item>().getMove());

                check(x, y, direction, pieces);
            }
            else if (CompileBoard.board[x, y].GetComponent<Item>().getColor() == color)
            {
                check(positionX, positionY, direction + 1, pieces);
            }
            else
            {
                CompileBoard.board[x, y].GetComponent<Item>().showMove();

                moves.Add(CompileBoard.board[x, y].GetComponent<Item>().getMove());

                check(positionX, positionY, direction + 1, pieces);
            }
        }




    }

    public static void checkPawn(int x, int y, bool moved)
    {
        // direction is equal to 1 or up

        y++;

        if (y < 8)
        {

            if (CompileBoard.board[x, y].GetComponent<Item>().getColor() == CompileBoard.colors.NULL)
            {
                CompileBoard.board[x, y].GetComponent<Item>().showMove();

                moves.Add(CompileBoard.board[x, y].GetComponent<Item>().getMove());

                if (!moved)
                {
                    if (y < 8)
                    {
                        if (CompileBoard.board[x, y + 1].GetComponent<Item>().getColor() == CompileBoard.colors.NULL)
                        {
                            CompileBoard.board[x, y + 1].GetComponent<Item>().showMove();

                            moves.Add(CompileBoard.board[x, y].GetComponent<Item>().getMove());
                        }
                    }
                }



            }
        }

        if (x + 1 < 8 && y + 1 < 8)
        {


            if (CompileBoard.board[x + 1, y + 1].GetComponent<Item>().getColor() != color &&
                CompileBoard.board[x + 1, y + 1].GetComponent<Item>().getColor() != CompileBoard.colors.NULL)
            {
                CompileBoard.board[x + 1, y + 1].GetComponent<Item>().showMove();

                moves.Add(CompileBoard.board[x, y].GetComponent<Item>().getMove());
            }
        }

        if (x - 1 > 0 && y + 1 < 8)
        {


            if (CompileBoard.board[x - 1, y + 1].GetComponent<Item>().getColor() != color &&
               CompileBoard.board[x - 1, y + 1].GetComponent<Item>().getColor() != CompileBoard.colors.NULL)
            {
                CompileBoard.board[x - 1, y + 1].GetComponent<Item>().showMove();

                moves.Add(CompileBoard.board[x, y].GetComponent<Item>().getMove());
            }

        }

    }

    public static void clear()
    {
        moves.Clear();
    }
}
