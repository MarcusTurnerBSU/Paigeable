using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class levelManager : MonoBehaviour
{
    public UnityEvent onReset;
    public GameObject levelCompleteDisplay;
    public Button resetButton;
    //empty 2d array to setup grid for level
    char[,] map;
    //how many homes reachable
    int homeCountMax;
    //how many homes have been reached
    int homeCountCurrent;
    int playerCurrentPosX;
    int playerCurrentPosY;

    private void onClickReset()
    {
        homeCountCurrent = 0;
        playerCurrentPosX = 10;
        playerCurrentPosY = 1;
        levelCompleteDisplay.SetActive(false);
        if(onReset != null)
            onReset.Invoke();
    }
    public bool movementCheck(int direction)
    {
        int tempPosY = playerCurrentPosY;
        tempPosY += direction;
        char tempChar = map[playerCurrentPosX, tempPosY];
        switch (tempChar)
        {
            case 'W':
                return false;
            case 'H':
                homeCountCurrent++;
                levelCompleteCheck();
                break;
        }
        playerCurrentPosY += direction;
        return true;
    }
    private void levelCompleteCheck()
    {
        if (homeCountMax == homeCountCurrent)
        {
            levelCompleteDisplay.SetActive(true);
        }
    }
    private void Awake()
    {
        levelCompleteDisplay.SetActive(false);
        resetButton.onClick.AddListener(onClickReset);
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
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
            {'W', 'A', '/', '/', '/', '/', '/', '/', '/', '/', '/', 'H', 'W'},
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
        };
        homeCountMax = 1;
        homeCountCurrent = 0;
        playerCurrentPosX = 10;
        playerCurrentPosY = 1;


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
