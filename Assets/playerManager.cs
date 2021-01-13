using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public playerController[] playerControllers;

    public bool allowInput = false;
    private int playersMoved;
    // Start is called before the first frame update
    void Start()
    {
        allowInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!allowInput)
            return;
            
           

        if (Input.GetKeyDown(KeyCode.A))
        {
            allowInput = false;
            for (int i = 0; i < playerControllers.Length; i++)
            {
                playerControllers[i].moveLeft();
            }

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            allowInput = false;
            for (int i = 0; i < playerControllers.Length; i++)
            {
                playerControllers[i].moveRight();
            }

        }
        //if avatar x and y is equal to home x and y {
        //stop movement/ show animation }
        //else { allow movement

    }

    public void onControllerMovementComplete()
    {
        playersMoved++;
        if (playerControllers.Length == playersMoved)
        {
            allowInput = true;
            playersMoved = 0;
        }
    }

    public void onElevatorToggle(int upX, int upY, int downX, int downY, bool isUp)
    {
        if (isUp)
        {
            for (int i = 0; i < playerControllers.Length; i++)
            {
                if (playerControllers[i].currentX == upX && playerControllers[i].currentY == upY)
                {
                    //player is at up position and should be told to move down
                    playerControllers[i].moveDown();
                }
            }
        }
        else
        {
            for (int i = 0; i < playerControllers.Length; i++)
            {
                if (playerControllers[i].currentX == downX && playerControllers[i].currentY == downY)
                {
                    //player is at down position and should be told to move up
                    playerControllers[i].moveUp();
                }
            }
        }
    }

    public void Reset()
    {
        allowInput = true;
        playersMoved = 0;

        for (int i = 0; i < playerControllers.Length; i++)
        {
            playerControllers[i].Reset();
        }
    }
}
