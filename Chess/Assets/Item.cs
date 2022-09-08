using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class Item
{
    private CompileBoard.colors color;  
    private CompileBoard.pieces pieces;
    private bool reserved;
    private string move; 

    public Item(CompileBoard.colors color, CompileBoard.pieces pieces, string move)
    {
        this.color = color;
        this.pieces = pieces; 
        reserved = true;
        this.move = move;   
    }

   public Item(char file, int row)
    {
        reserved = false;
        pieces = CompileBoard.pieces.NULL;
        setMove(file, row);
        color = CompileBoard.colors.NULL;
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


}
