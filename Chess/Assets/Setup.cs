using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// class does proper setup before gameplay.
public class Setup : MonoBehaviour
{
    // Start is called before the first frame update

    private static GameObject menu;

    public static TextMeshPro errors;


    public static TMP_InputField moves;
    public static TextMeshProUGUI piece;
    public static Button start;
    public static TextMeshProUGUI moveSet; 
    

    void Start()
    {
       // menu = GameObject.FindGameObjectWithTag("Menu");
        CompileBoard.createBoard();

        piece = GameObject.FindGameObjectWithTag("PieceText").GetComponent<TextMeshProUGUI>();

        start = GameObject.FindGameObjectWithTag("GoButton").GetComponent<Button>();

        moveSet = GameObject.FindGameObjectWithTag("moves").GetComponent<TextMeshProUGUI>();

        start.enabled = false;
 

    }

    // function will be removed after game code is done 
    public void dataValidation()
    {

    }

}
