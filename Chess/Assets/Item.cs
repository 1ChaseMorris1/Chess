using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Experimental;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IDropHandler
{
    private CompileBoard.colors color;  
    private CompileBoard.pieces pieces;
    private bool reserved;
    private string move;
    private Color clr;
    private bool movedFirst; 

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
        return this.move; 
    }

    public void turnOnObject()
    {
        gameObject.SetActive(true);
       // square.SetActive(true); 
    }

    public void turnOffObject()
    {
        gameObject.SetActive(false);
      //  square.SetActive(false);
    }

    public void showMove()
    {
        gameObject.GetComponent<RawImage>().color = Color.blue; 
        //square.GetComponent<RawImage>().color = Color.blue; 
    }

    public void offMove()
    {
        gameObject.GetComponent<RawImage>().color = clr;

    }

    public void setItem(GameObject item)
    {
       
    //    this.square = item;
    }

    public void OnDrop(PointerEventData eventData)
    {
        // gameobject that is being dragged.
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            eventData.pointerDrag.GetComponent<Piece>().isMoved();
        }
    }
}
