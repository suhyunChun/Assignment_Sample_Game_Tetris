using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    enum BlockType 
    {
        J,
        L,
        Long,
        O,
        S,
        T,
        Z
    }
    public static GameManager I;
    public static int heightOfGrid = 20;
    public static int widthOfGrid = 10;
    private static Transform[,] board = new Transform[widthOfGrid, heightOfGrid];//board;


    void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsValid(Vector2 blockPos)
    {
            int PosX = Mathf.RoundToInt(blockPos.x);
            int PosY = Mathf.RoundToInt(blockPos.y);
            if (PosX < 0 || PosY < 0 || PosX >= widthOfGrid|| board[PosX,PosY] != null)
            {
                return false;
            }
        return true;
    }

    private String GetRandomBlockType()
    {
        BlockType rdBlock = (BlockType)UnityEngine.Random.Range(0, 7);
        Debug.Log($"Prefabs/{rdBlock.ToString()}");
        return $"Prefabs/{rdBlock.ToString()}";
    }
    private void SpawnBlock()
    {
        GameObject nextBlcok = (GameObject)Instantiate(Resources.Load(GetRandomBlockType(),typeof(GameObject)), new Vector2(5.0f, 19.0f),Quaternion.identity);
    }
}
