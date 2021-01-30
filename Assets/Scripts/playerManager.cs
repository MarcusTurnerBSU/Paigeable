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
        //if true get out of the update method
        if (!allowInput)
            return;
            
           
        // if 'A' is pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
            //disabled input to allow all avatars to move
            allowInput = false;
            //for loop running through each avatar
            for (int i = 0; i < playerControllers.Length; i++)
            {
                //all avatars move left
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
    }

    //check to see if all movement are complete, if so increment 'playersMoved' and allow input again
    public void onControllerMovementComplete()
    {
        playersMoved++;
        if (playerControllers.Length == playersMoved)
        {
            allowInput = true;
            playersMoved = 0;
        }
    }

    //checking to see if the elevator platform is up or down
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

    //when called allows the user to start playing
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
