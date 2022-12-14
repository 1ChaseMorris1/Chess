using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    public CompileBoard.colors color; 
   // private int SIZE = 8; 
    public int positionX; 
    public int positionY;
    public ArrayList moves = new ArrayList();

    public void checkMoves()
    {

        check(positionY, positionX, CompileBoard.directions.UP);

      //  print(moves.Count);

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                for(int k = 0; k < moves.Count; k++)
                {
                    /*
                    if (moves[k].Equals(CompileBoard.board[i,j].getMove()))
                    {
                        CompileBoard.getTile(i, j).showMove();
                    }
                    */
                }
            }
        }
        




    }

    private void check(int y, int x, CompileBoard.directions direction)
    {
        //print(direction);  

        if (direction == CompileBoard.directions.END)
            return;

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

        /*
        if ((x > 7 || x < 0) || (y > 7 || y < 0))
        {
            check(positionY, positionX, direction + 1);
        }
        else
        {
            if (CompileBoard.board[y, x].getColor() == CompileBoard.colors.NULL)
            {
                moves.Add(CompileBoard.board[y, x].getMove());
                check(y, x, direction);
            }
            else if (CompileBoard.board[y, x].getColor() == color)
            {
                check(positionY, positionX, direction + 1);
            }
            else
            {
                moves.Add(CompileBoard.board[y, x].getMove());
                check(positionY, positionX, direction + 1);
            }
        }
        */
    }

    public ArrayList getMoves()
    {
        check(positionY, positionX, CompileBoard.directions.UP);
        return moves; 
    }

}
