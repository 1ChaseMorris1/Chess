using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    // returns to original position if dropped on a piece or outside the board. 
    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<Piece>().setParentBack();

        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.GetComponent<Piece>().getPosition();

        eventData.pointerDrag.GetComponent<Piece>().getCanvas().blocksRaycasts = true;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                CompileBoard.board[i, j].GetComponent<Item>().offMove();
            }
        }

    }
}
