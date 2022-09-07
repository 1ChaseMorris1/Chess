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

    public void checkMoves()
    {
        // checks right
        for(int i = positionX; i < SIZE; i++)
        {
            if (CompileBoard.board[positionY, i].getColor() == color)
            {
                break; 
            }

          //  if (CompileBoard.board[positionY, i].getColor() !=)
        }
    }



}
