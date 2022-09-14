using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static CompileBoard;

public class Piece : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler, IDropHandler
{
    public CompileBoard.pieces piece;
    public CompileBoard.colors color;

    public int positionX;
    public int positionY;

    private bool moved;
    private Vector3 position; 
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

  //  private ArrayList moves = new ArrayList();

    private void Awake()
    {

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        moved = false;
        position = gameObject.GetComponent<RectTransform>().anchoredPosition; 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;

        transform.SetParent(CompileBoard.parent[2].transform);

        // errors
        switch (piece)
        {
            case CompileBoard.pieces.PAWN:

                Movement.setVariables(positionX,positionY,color);
                Movement.checkPawn(positionX,positionY,moved);
                //moves = Movement.moves; 
                break;
            case CompileBoard.pieces.KING:

                break;
            case CompileBoard.pieces.KNIGHT:

                break;
            case CompileBoard.pieces.BISHOP:
                Movement.setVariables(positionX, positionY, color);
                Movement.check(positionX, positionY, CompileBoard.directions.RIGHT, piece); 
                break; 

            default:

                Movement.setVariables(positionX, positionY, color);
                Movement.check(positionX, positionY, CompileBoard.directions.UP, piece);
               // moves = Movement.moves;

                break; 
        }
   
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CompileBoard.getActivePlayer() == 1)
           // rectTransform.anchoredPosition.Equals(eventData.position / canvas.scaleFactor);
            rectTransform.anchoredPosition += eventData.delta / CompileBoard.canvas.scaleFactor;     // set to mouse position. 

        else
            rectTransform.anchoredPosition += eventData.delta / CompileBoard.canvas.scaleFactor;

    } 

    
    public void OnPointerUp(PointerEventData eventData)
    {

        //print("Drop");

        //eventData.pointerDrag.GetComponent<Item>().OnDrop(eventData); 

        /*
        print("drop");
        eventData.pointerDrag.GetComponent<Piece>().getCanvas().blocksRaycasts = true;

       eventData.pointerDrag.gameObject.transform.position = position;

        gameObject.transform.position = position;

        
        
        for(int i = 0; i < Movement.moves.Count; i++)
        {
         //   if(Movement.moves[i].Equals)
        }

        
        
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                CompileBoard.board[i, j].GetComponent<Item>().offMove();
            }
        }
        
        
        */


    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void setPiece(GameObject gameObject)
    {
      //  _piece = gameObject; 
    }

    public void isMoved()
    {
        moved = true;
    }

    public Vector3 getPosition()
    {
        return position; 
    }

    public void setPosition(Vector3 pos)
    {
        position = pos;
    }

    public CanvasGroup getCanvas()
    {
        return canvasGroup;
    }

    /*
    public void OnPointerUp(PointerEventData eventData)
    {
        
        GetComponent<Piece>().getCanvas().blocksRaycasts = true;

        gameObject.GetComponent<RectTransform>().anchoredPosition = position;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                CompileBoard.board[i, j].GetComponent<Item>().offMove();
            }
        }
        
    }
        */

    public void resetBoard()
    {
        CompileBoard.board[positionX,positionY].GetComponent<Item>().resetItem();
    }

    public void setCoordinates(int x, int y)
    {
        positionX = x;
        positionY = y; 
    }

    public void setParentBack()
    {
        if (color == CompileBoard.colors.WHITE)
            transform.SetParent(CompileBoard.parent[0].transform);
        else
            transform.SetParent(CompileBoard.parent[1].transform);
    }

    public void OnDrop(PointerEventData eventData)
    {

        bool moved = false; 

        if(eventData != null)
        {
            eventData.pointerDrag.GetComponent<Piece>().setParentBack();

            for (int i = 0; i < Movement.moves.Count; i++)
            {
                if (CompileBoard.board[positionX, positionY].GetComponent<Item>().getMove().Equals(Movement.moves[i]))
                {

                    eventData.pointerDrag.GetComponent<Piece>().setPosition(GetComponent<RectTransform>().anchoredPosition);                    // sets the piece variable 

                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;      // sets the pieces new position

                    CompileBoard.board[positionX, positionY].GetComponent<Item>().setReserved(true);                                                                                                            // makes spot reserved 

                    CompileBoard.board[positionX, positionY].GetComponent<Item>().setColor(eventData.pointerDrag.GetComponent<Piece>().color);                                                                 // setting up the item class

                    CompileBoard.board[positionX, positionY].GetComponent<Item>().setPiece(eventData.pointerDrag.GetComponent<Piece>().piece);

                    eventData.pointerDrag.GetComponent<Piece>().resetBoard();

                    eventData.pointerDrag.GetComponent<Piece>().getCanvas().blocksRaycasts = true;

                    eventData.pointerDrag.GetComponent<Piece>().setCoordinates(positionX, positionY);

                    eventData.pointerDrag.GetComponent<Piece>().isMoved();

                    Destroy(gameObject);

                    moved = true;

                   // CompileBoard.changeActivePlayer();

                    break;
                }
            }

            if(!moved)
            {
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
        }
    }
}
