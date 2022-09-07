using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Pawn : MonoBehaviour
{
    public CompileBoard.colors color; 
    public int positionX;
    public int positionY;
    // moving 1 up makes the offset go down by 1, black pawns have no offset only white ones do. 
    private int offset = 4;
    ArrayList moveSetX = new ArrayList();
    ArrayList moveSetY = new ArrayList();

    private bool movedFirst = false;

    void movePawn()
    {
        if (CompileBoard.board[positionY, positionX].getReserved() == false)
        {

        }
    }

    public void showMoves()
    {
        // if menuscreen showMoves() == true then show moves else just dont light up the path - turtles




        print(CompileBoard.board[positionY , positionX].getReserved());

    }

    public void pawnSelected()
    {
       Setup.piece.text = CompileBoard.convert(positionX) + (positionY + 1) + " PAWN"; //  + (positionX++) + "PAWN")
       Setup.start.enabled = true;
       
        getMoves();
    }

    public void getMoves()
    {
        string moves = "";

        if(!movedFirst)
        {
            for(int i = positionY + 1; i < positionY + 3; i++)
            {
                if (!CompileBoard.checkSquare(i, positionX))
                {
                    moves = moves + CompileBoard.convert(positionX) + (i + 1) + '\n';

                    moveSetX.Add(positionX);
                    moveSetY.Add(i);

                } else
                {
                    break; 
                }
            }
            
        }

        if(positionX + 1 != 8)
        {
            if (CompileBoard.board[positionY + 1, positionX + 1].getColor() == CompileBoard.colors.BLACK)
            {
                moves = moves + CompileBoard.convert(positionX + 1) + (positionY + 1) + '\n';
            }

        }
        
        if (positionX - 1 != -1)
        {
            if (CompileBoard.board[positionY + 1, positionX - 1].getColor() == CompileBoard.colors.BLACK)
            {
                moves = moves + CompileBoard.convert(positionX - 1) + (positionY + 1) + '\n';
            }
        }
       

        Setup.moveSet.text = moves;


    }

    private int off_set()
    {
        return positionY - offset;
    }

}
