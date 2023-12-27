using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager I;
    public static int heightOfGrid = 20;
    public static int widthOfGrid = 10;
    private static Transform[,] Board = new Transform[widthOfGrid, heightOfGrid];//board;


    void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsValid(Vector2 blockPos)
    {
            int PosX = Mathf.RoundToInt(blockPos.x);
            int PosY = Mathf.RoundToInt(blockPos.y);


            if (PosX < 0 || PosY < 0 || PosX >= widthOfGrid|| Board[PosX,PosY] != null)
            {
                return false;
            }
        return true;
    }
}
