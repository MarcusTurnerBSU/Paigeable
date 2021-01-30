using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class levelManager : MonoBehaviour
{
    public playerManager playerManager;
    public elevatorMovement elevatorMovement;
    public UnityEvent onReset;
    public GameObject levelCompleteDisplay;
    public Button resetButton;
    //empty 2d array to setup grid for level
    char[,] map;
    //how many homes reachable
    public int homeCountMax;
    //how many homes have been reached
    int homeCountCurrent;

    //everything starts to allow the player to play again
    private void Awake()
    {
        levelCompleteDisplay.SetActive(false);
        resetButton.onClick.AddListener(onClickReset);
        generateMap();
        homeCountCurrent = 0;

    }

    //everything resets to allow the player to play again
    private void onClickReset()
    {
        homeCountCurrent = 0;
        levelCompleteDisplay.SetActive(false);
        if(onReset != null)
            onReset.Invoke();
        playerManager.Reset();
        elevatorMovement.Reset();
        generateMap();
    }

    //check to see if a character is hitting a wall if so deny move
    public bool movementCheck(int currentX, int currentY, int direction)
    {
        
        int tempPosY = currentY;
        tempPosY += direction;
        char tempChar = map[currentX, tempPosY];
        switch (tempChar)
        {
            case 'W':
                //Debug.Log("Wall");
                return false;
        }
        
        return true;
    }

    //checking if the character is at it's home
    public bool homeCheck(int currentX, int currentY, char homeID)
    {
        char tempChar = map[currentX, currentY];
        if (tempChar == homeID)
        {
            //Debug.Log("Home: X: " + currentX + ", Y: " + currentY);
            homeCountCurrent++;
            levelCompleteCheck();
            return true;
        }

        return false;
    }

    //check to see if a character has landed on the ground
    public bool groundCheck(int currentX, int currentY)
    {
        char tempChar = map[currentX + 1, currentY];
        if (tempChar == 'W')
        {
            //Debug.Log("Ground: X: " + currentX + ", Y: " + currentY);
            return false;
        }
        if (tempChar == 'E')
        {
            //Debug.Log("Elevator Platform: X: " + currentX + ", Y: " + currentY);
            return false;
        }
        return true;
    }

    //display level complete to the user if, condition equals true
    private void levelCompleteCheck()
    {
        if (homeCountMax == homeCountCurrent)
        {
            levelCompleteDisplay.SetActive(true);
        }
    }
    
    
    //updating the map, so it knows where the elevator platform is
    public void onElevatorToggle(int x, int y, bool isUp)
    {
        if (isUp)
        {
            map[x, y] = '/';
        }
        else
        {
            map[x, y] = 'E';
        }
    }

    //generating the default map whe called upon
    public void generateMap()
    {
        map = new char[,]
        {
            //visual look of grid positions for map
            //avatars starting locations, home locations and platform locations
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
            {'W', '/', '/', '/', '/', '/', '/', '/', '/', '/', '/', '1', 'W'},
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', '/', '/', 'W', 'W', 'W'},
            {'W', '/', '/', '/', '/', '/', '/', '/', '/', '/', '/', '2', 'W'},
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
        };
    }
}
