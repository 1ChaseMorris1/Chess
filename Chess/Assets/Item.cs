using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private CompileBoard.colors color;  
    private CompileBoard.pieces pieces;
    private bool reserved; 

    public Item(CompileBoard.colors color, CompileBoard.pieces pieces)
    {
        this.color = color;
        this.pieces = pieces; 
        reserved = true; 
    }

   public Item()
    {
        reserved = false;
        color = CompileBoard.colors.NULL;
        pieces = CompileBoard.pieces.NULL;
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
}
