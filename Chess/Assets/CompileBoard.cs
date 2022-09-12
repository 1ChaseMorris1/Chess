using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class CompileBoard {

    private static int SIZE = 8;
    private static int activePlayer = 1;

    private static GameObject[] squares;
    public static GameObject[,] board = new GameObject[8,8];
    private static GameObject[] Pieces;


    // public static Setup setup;
    public static ArrayList totalMoves;
    //private static GameObject[] squares;

    //private static GameObject[] allPieces;

    public enum pieces { NULL = 0,  PAWN =  1, CASTLE = 2, KNIGHT = 3, BISHOP = 4, QUEEN = 5, KING = 6 };
    public enum colors { NULL = 0, WHITE = 1, BLACK = 2};
    public enum directions { UP = 0, DOWN = 1, LEFT = 2, RIGHT = 3, DUPLEFT = 4, DUPRIGHT = 5, DDOWNLEFT = 6, DDOWNRIGHT = 7, END = 8 }

    public static Canvas canvas;

    public static void createBoard()
    {

        squares = GameObject.FindGameObjectsWithTag("square");
        Pieces = GameObject.FindGameObjectsWithTag("piece");

        int len = 0;

        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {

                board[i, j] = squares[len];

                board[i, j].GetComponent<Item>().setColor();

                if (board[i,j].GetComponent<Item>().getPiece() == pieces.PAWN)
                    board[i,j].GetComponent<Item>().setMoved();

                len++;

                /*
                board[i, j] = squares[len].AddComponent<Item>();
                board[i, j].setItem(squares[len]);
                board[i, j].instill(getCharacter(i), j); 
                */

            }
        }



        setBoard();

        /*
        MonoBehavior.print(board[0, 0].move);

        MonoBehaviour.print(squares[0].GetComponent<Item>().move);

        GameObject gameObjects = new GameObject();

        for (int i = 0; i < allPieces.Length; i++)
        {
            Pieces[i] = allPieces[i].AddComponent<Piece>();
            Pieces[i].setPiece(allPieces[i]);
        }

        setBoard();
        */

    }

    /*
    public static Item getTile(int i, int j)
    {
        return board[i, j].gameObject;
    }
    */

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
                /*
                if (board[i,j].getReserved() == true)
                {
                    display = display + "*";  
                } else
                {
                    display = display + "#"; 
                }
                */
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
        /*
        if (board[y,x].getReserved())
        {
            return true; 
        } else
        {
            return false;
        }
        */
        return false;
    }

    public static int convert(char x)
    {
        return (System.Convert.ToInt32(x) - 65); 
    }

    private static char getCharacter(int x)
    {
        return System.Convert.ToChar((x + 65));
    }

    public static void printMoves()
    {
        for(int i = 0; i < SIZE; i++)
        {
            for(int j = 0; j < SIZE; j++)
            {
            //    MonoBehaviour.print(' ' + board[i,j].getMove() + ' ');
            }
            MonoBehaviour.print('\n');
        }
    }


    private static void setBoard()
    {
        board[3, 0].GetComponent<Item>().newPiece(colors.WHITE, pieces.QUEEN, board[3, 0].GetComponent<Item>().getMove());

        for (int i = 0; i < 8; i++)
        {
            board[i, 1].GetComponent<Item>().newPiece(colors.WHITE, pieces.PAWN, board[i , 1].GetComponent<Item>().getMove());
            board[i, 6].GetComponent<Item>().newPiece(colors.BLACK, pieces.PAWN, board[i , 6].GetComponent<Item>().getMove());
        }

        colors ex = colors.WHITE;
        int side = 0;

        for (int i = 0; i < 2; i++)
        {
            if (i == 1)
            {
                side = 7;
                ex++;
            }

            board[0, side].GetComponent<Item>().newPiece(ex, pieces.CASTLE, board[0,side].GetComponent<Item>().getMove());
            board[7, side].GetComponent<Item>().newPiece(ex, pieces.CASTLE, board[7,side].GetComponent<Item>().getMove());

            board[1,side].GetComponent<Item>().newPiece(ex, pieces.KNIGHT, board[1,side].GetComponent<Item>().getMove());
            board[6,side].GetComponent<Item>().newPiece(ex, pieces.KNIGHT, board[6,side].GetComponent<Item>().getMove());

            board[2, side].GetComponent<Item>().newPiece(ex, pieces.BISHOP, board[2, side].GetComponent<Item>().getMove());
            board[5, side].GetComponent<Item>().newPiece(ex, pieces.BISHOP, board[5, side].GetComponent<Item>().getMove());

            board[3, side].GetComponent<Item>().newPiece(ex, pieces.QUEEN, board[3, side].GetComponent<Item>().getMove());
            board[4, side].GetComponent<Item>().newPiece(ex, pieces.KING, board[4, side].GetComponent<Item>().getMove());

        }
        

    }
}
