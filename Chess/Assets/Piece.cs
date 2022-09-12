using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Piece : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public CompileBoard.pieces piece;
    public CompileBoard.colors color;
    public int positionX;
    public int positionY;
    private bool moved; 
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        moved = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       // canvasGroup.blocksRaycasts = false;

        switch (piece)
        {
            case CompileBoard.pieces.PAWN:
                Movement.setVariables(positionX,positionY,color);
                Movement.checkPawn(positionX,positionY,moved);
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

                break; 
        }
   
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / CompileBoard.canvas.scaleFactor; // set to mouse position. 

    }

    public void OnDrop(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                CompileBoard.board[i, j].GetComponent<Item>().offMove();
            }
        }

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
}
