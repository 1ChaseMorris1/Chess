using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CompileBoard {

    private static int SIZE = 8;
    private static int activePlayer = 1;
    public static Item[,] board = new Item[8,8];
    public enum pieces { NULL = 0,  PAWN =  1, CASTLE = 2, KNIGHT = 3, BISHOP = 4, QUEEN = 5, KING = 6 };
    public enum colors { NULL = 0, WHITE = 1, BLACK = 2};
   public static void createBoard()
    {
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                board[i, j] = new Item(); 
            }
        }
       
        
        for(int i = 0; i < SIZE; i++)
        {
            board[1, i].setPiece(pieces.PAWN); 
            board[1,i].setReserved(true); 
            board[1, i].setColor(colors.WHITE); 
        }

        for (int i = 0; i < SIZE; i++)
        {
            board[3, i].setPiece(pieces.PAWN);
            board[3, i].setReserved(true);
            board[3, i].setColor(colors.BLACK);
        }

    }

    public static int getActivePlayer()
    {
        return activePlayer;
    }

    public static void changeActivePlayer()
    {
        if (activePlayer == 1)
            activePlayer = 2;
        else
            activePlayer = 1;
    }

    public static void printBoard()
    {
        string display = ""; 
        for(int i = 0; i <  SIZE; i++)
        {
            for(int j = 0; j < SIZE; j++)
            {
                if (board[i,j].getReserved() == true)
                {
                    display = display + "*";  
                } else
                {
                    display = display + "#"; 
                }
            }
            display = display + "\n"; 
        }

        MonoBehaviour.print(display); 
    }

    public static string convert(int pos)
    {
        char x = 'A';
        int y = 1; 
        
        while(y <= pos)
        {
            int j = x;
            j++;
            x = System.Convert.ToChar(j);
            y++;
        }

        return System.Convert.ToString(x); 
    }

    public static bool checkSquare(int y, int x)
    {
        if (board[y,x].getReserved())
        {
            return true; 
        } else
        {
            return false;
        }
    }

    public static int convert(char x)
    {
        return (System.Convert.ToInt32(x) - 65); 
    }

}
