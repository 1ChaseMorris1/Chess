using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    public CompileBoard.colors color; 
    private int SIZE = 8; 
    public int positionX; 
    public int positionY;
    public ArrayList moves = new ArrayList();
    private enum directions { UP = 0, DOWN = 1, LEFT = 2, RIGHT = 3, DUPLEFT = 4, DUPRIGHT = 5, DDOWNLEFT = 6, DDOWNRIGHT = 7, END = 8}

    public void checkMoves()
    {

       // print(positionY);

        check(positionY,positionX, directions.UP); 
        
        for(int i = 0; i < moves.Count; i++)
        {
         //   print(moves[i]); 
        }
        


    }

    void check(int y, int x, directions direction)
    {
        print(direction);  

        if (direction == directions.END)
            return;

        switch (direction)
        {
            case directions.UP:
                y++;
                break;
            case directions.DOWN:
                y--;
                break;
            case directions.LEFT:
                x--;
                break;
            case directions.RIGHT:
                x++;
                break;
            case directions.DUPRIGHT:
                y++; x++;
                break;
            case directions.DUPLEFT:
                y++; x--;
                break;
            case directions.DDOWNLEFT:
                y--; x--;
                break;
            case directions.DDOWNRIGHT:
                y--; x++;
                break; 
        }

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
    }



}
