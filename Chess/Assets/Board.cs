using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CompileBoard;

public static class Board
{
    private static int SIZE = 8; 
    private static GameObject[] squares;
    private static Item[,] board = new Item[SIZE, SIZE];
    public enum directions { UP = 0, DOWN = 1, LEFT = 2, RIGHT = 3, DUPLEFT = 4, DUPRIGHT = 5, DDOWNLEFT = 6, DDOWNRIGHT = 7, END = 8 }
    public enum colors { NULL = 0, WHITE = 1, BLACK = 2 };
    public enum pieces { NULL = 0, PAWN = 1, CASTLE = 2, KNIGHT = 3, BISHOP = 4, QUEEN = 5, KING = 6 };


    public static void compile()
    {
        squares = GameObject.FindGameObjectsWithTag("square");
       // print(squares.Length);

        int len = 0;

        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                board[i, j] = squares[len].AddComponent<Item>();
                board[i, j].setItem(squares[len]);
                len++;
            }
        }

      //  board[0, 0].newPiece(colors.WHITE, pieces.QUEEN, board[3, 3].getMove());
    }

    public static Item getTile(int i, int j)
    {
        return board[i, j];
    }

}
