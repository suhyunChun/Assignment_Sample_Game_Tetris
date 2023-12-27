using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{

    private float fallingSpeed = 0.5f;
    private float fall = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBlockLocation();
    }

    private void ChangeBlockLocation()
    {

        // input���� valid���� ���� üũ �� �� ���� 
        if (IsAllBlocksValid())
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= fallingSpeed)
            {
                MoveDown();
                fall = Time.time;

            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Rotate();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight();
            }
        }
  
    }
    private void MoveDown()
    {
        transform.position += new Vector3(0, -1, 0);
    }
    private void Rotate()
    {
        transform.Rotate(0, 0, 90);

    }
    private void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0);
    }
    private void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0);
    }

    private bool IsAllBlocksValid()
    {

        foreach(Transform children in transform)
        {
           if(!GameManager.I.IsValid(children.transform.position))
            {
                return false;
            }
        }

        return true;
    }
}