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
    public static Transform[,] board = new Transform[widthOfGrid, heightOfGrid];//board;

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

    public void AddBlockToGrid(BlockMovement block)
    {
        foreach (Transform children in block.transform)
        {
            int PosX = Mathf.RoundToInt(children.transform.position.x);
            int PosY = Mathf.RoundToInt(children.transform.position.y);

            if(PosY < heightOfGrid)
            {
                board[PosX, PosY] = children;
            }
        }
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
        return $"Prefabs/{rdBlock.ToString()}";
    }
    public void SpawnBlock()
    {
        GameObject nextBlcok = (GameObject)Instantiate(Resources.Load(GetRandomBlockType(),typeof(GameObject)), new Vector2(5.0f, 19.0f),Quaternion.identity);
    }

    public bool IsFullAt(int height)
    {
        for(int i = 0; i < widthOfGrid; i++)
        {
            if (board[i, height] == null)
                return false;
        }
        return true;
    }

    public void DeleteFullRow(int height) 
    {
        for(int i =0; i<widthOfGrid; i++)
        {
            Destroy(board[i, height].gameObject);
            board[i, height] =null;
        }
    }

    public void MoveDownRow(int height)
    {

        for (int j = height; j < heightOfGrid; j++)
        {
            for (int i = 0; i < widthOfGrid; i++)
            {
                if (board[i, j] != null) //블록이 있는 곳에만 
                {
                    Debug.Log("move down");
                    board[i, j - 1] = board[i, j];
                    board[i, j] = null;
                    board[i, j - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    public void UpdatingBoardMap()
    {
  
            for (int i = heightOfGrid-1; i >=0; i--)
            {
                if (IsFullAt(i))
                {
                    Debug.Log($"full at {i}");
                    DeleteFullRow(i);
                    MoveDownRow(i);
                }
            }
        }
    

    public void GameOver()
    {
        Debug.Log("Game over");
    }
}
