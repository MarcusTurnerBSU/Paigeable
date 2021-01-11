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

    private void onClickReset()
    {
        homeCountCurrent = 0;
        levelCompleteDisplay.SetActive(false);
        if(onReset != null)
            onReset.Invoke();
    }
    public bool movementCheck(int currentX, int currentY, int direction)
    {
        
        int tempPosY = currentY;
        tempPosY += direction;
        char tempChar = map[currentX, tempPosY];
        switch (tempChar)
        {
            case 'W':
                Debug.Log("Wall?");
                return false;
            case 'H':
                homeCountCurrent++;
                levelCompleteCheck();
                break;
        }
        
        return true;
    }

    public bool groundCheck(int currentX, int currentY)
    {
        char tempChar = map[currentX + 1, currentY];
        if (tempChar == 'W')
        {
            return false;
        }
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
            {'W', '/', '/', '/', '/', '/', '/', '/', '/', '/', '/', '/', 'W'},
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', '/', '/', 'W', 'W', 'W'},
            {'W', 'A', '/', '/', '/', '/', '/', '/', '/', '/', '/', 'H', 'W'},
            {'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
        };
        homeCountMax = 1;
        homeCountCurrent = 0;

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
