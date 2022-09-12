using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// class does proper setup before gameplay.
public class Setup : MonoBehaviour
{

    private void Awake()
    {
        CompileBoard.createBoard();

        CompileBoard.canvas = GameObject.FindGameObjectWithTag("canvas").GetComponent<Canvas>(); 
    }

}
