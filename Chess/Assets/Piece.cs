using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Piece : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler, IPointerUpHandler
{
    public CompileBoard.pieces piece;
    public CompileBoard.colors color;
    public int positionX;
    public int positionY;
    private bool moved;
    private Vector3 position; 
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

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

        switch (piece)
        {
            case CompileBoard.pieces.PAWN:

                Movement.setVariables(positionX,positionY,color);
                Movement.checkPawn(positionX,positionY,moved);
               // Movement.clear();

                break;
            case CompileBoard.pieces.KING:

                break;
            case CompileBoard.pieces.KNIGHT:

                break;
            case CompileBoard.pieces.BISHOP:
                // direction is increased. 
                break; 

            default:

                Movement.setVariables(positionX, positionY, color);
                Movement.check(positionX, positionY, CompileBoard.directions.UP, piece);
               // Movement.clear();

                break; 
        }
   
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / CompileBoard.canvas.scaleFactor; // set to mouse position. 

    }

    public void onPointerUp()
    {

    }


    public void OnDrop(PointerEventData eventData)
    {
        print("drop");
       // eventData.pointerDrag.GetComponent<Piece>().getCanvas().blocksRaycasts = true;

       // eventData.pointerDrag.gameObject.transform.position = position;

        //gameObject.transform.position = position;

        /*

        for(int i = 0; i < Movement.moves.Count; i++)
        {
         //   if(Movement.moves[i].Equals)
        }

        */
        /*
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

    public void OnPointerUp(PointerEventData eventData)
    {
        /*
        GetComponent<Piece>().getCanvas().blocksRaycasts = true;

        gameObject.GetComponent<RectTransform>().anchoredPosition = position;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                CompileBoard.board[i, j].GetComponent<Item>().offMove();
            }
        }
        */
    }

    public void resetBoard()
    {
        CompileBoard.board[positionX,positionY].GetComponent<Item>().resetItem();
    }
}
