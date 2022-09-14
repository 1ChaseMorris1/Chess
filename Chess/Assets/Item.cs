using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Experimental;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Item : MonoBehaviour, IDropHandler
{
    private CompileBoard.colors color;  
    private CompileBoard.pieces pieces;
    private bool reserved;


    private string move;

    private Color clr;

    private bool movedFirst;

    private int positionX; 
    private int positionY;

   // [SerializeField] private GameObject square; 



    public void newPiece (CompileBoard.colors color, CompileBoard.pieces pieces, string move)
    {
        this.color = color;
        this.pieces = pieces; 
        reserved = true;
        this.move = move;   

    
    }

   public void instill (char file, int row)
    {
        reserved = false;
        pieces = CompileBoard.pieces.NULL;
        setMove(file, row);
        color = CompileBoard.colors.NULL;
        clr = gameObject.GetComponent<RawImage>().color;
        print(clr);
   }

    public void setMoved()
    {
        movedFirst = false;
    }

    public void setColor()
    {
        clr = gameObject.GetComponent<RawImage>().color;
    }

    public CompileBoard.colors getColor()
    {
        return color; 
    }

    public void setColor(CompileBoard.colors color)
    {
        this.color = color; 
    }

    public CompileBoard.pieces getPiece()
    {
        return pieces;
    }

    public void setPiece(CompileBoard.pieces pieces)
    {
        this.pieces = pieces; 
    }

    public void setReserved(bool reserved)
    {
        this.reserved = reserved; 
    }

    public bool getReserved()
    {
        return reserved; 
    }

    public void setMove(char file, int row)
    {
        move = System.Convert.ToString(file) + System.Convert.ToString(row);
    }

    public string getMove()
    {
        return move; 
    }

    public void turnOnObject()
    {
        gameObject.SetActive(true);
       // square.SetActive(true); 
    }

    public void turnOffObject()
    {
        gameObject.SetActive(false);
    }

    public void showMove()
    {
        gameObject.GetComponent<RawImage>().color = Color.blue; 
    }

    public void offMove()
    {
        gameObject.GetComponent<RawImage>().color = clr;

    }

    public void setCoordinates(int x, int y)
    {
        positionX = x;
        positionY = y;
    }

    public void resetItem()
    {
        color = CompileBoard.colors.NULL;
        pieces = CompileBoard.pieces.NULL; 
        reserved = false;
    }




    public void OnDrop(PointerEventData eventData)
    {
        bool moved = false; 
        // gameobject that is being dragged.
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<Piece>().setParentBack();

            for(int i = 0; i < Movement.moves.Count; i++)
            {
                if (move.Equals(Movement.moves[i]))
                {
                    // move piece 

                    eventData.pointerDrag.GetComponent<Piece>().setPosition(GetComponent<RectTransform>().anchoredPosition);                    // sets the piece variable 

                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;      // sets the pieces new position

                    reserved = true;                                                                                                            // makes spot reserved 

                    color = eventData.pointerDrag.GetComponent<Piece>().color;                                                                  // setting up the item class

                    pieces = eventData.pointerDrag.GetComponent<Piece>().piece;

                    eventData.pointerDrag.GetComponent<Piece>().resetBoard();

                    eventData.pointerDrag.GetComponent<Piece>().getCanvas().blocksRaycasts = true;

                    eventData.pointerDrag.GetComponent<Piece>().setCoordinates(positionX, positionY);

                    eventData.pointerDrag.GetComponent<Piece>().isMoved();

                    moved = true;

                   // CompileBoard.changeActivePlayer();

                    break;
                }

            }

            if (!moved)
            {
                // piece goes back to original area
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.GetComponent<Piece>().getPosition();

                eventData.pointerDrag.GetComponent<Piece>().getCanvas().blocksRaycasts = true;
            }

            // set all of the colors back to normal.
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    CompileBoard.board[i, j].GetComponent<Item>().offMove();
                }
            }

            Movement.clear();

            /*
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            eventData.pointerDrag.GetComponent<Piece>().getCanvas().blocksRaycasts = true;


            for (int i = 0; i < Movement.moves.Count; i++)
            {

                if (Movement.moves[i].Equals(move))
                {

                    eventData.pointerDrag.GetComponent<Piece>().isMoved(); 
                    Movement.clear();

                    eventData.pointerDrag.GetComponent<Piece>().resetBoard();

                    CompileBoard.board[positionX, positionY].GetComponent<Item>().newPiece(color, pieces, move);


                    break;
                } else
                {
                    // reset back to original position
                }
            }
            */

        }
    }


}
