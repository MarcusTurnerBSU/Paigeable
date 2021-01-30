using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorMovement : MonoBehaviour
{
    public playerManager playerManager;
    public levelManager levelManager;
    
    public float elevatorYUp, elevatorYDown;
    public int downX, downY, upX, upY;
    private bool isUp = false;
    private int elevatorPlatformUpX;

    // Start is called before the first frame update
    void Start()
    {
        isUp = false;
        transform.localPosition = new Vector3(0, elevatorYDown, 0);
        elevatorPlatformUpX = upX + 1;
    }

    //resetting these variables so elevators start in the right positions
    public void Reset()
    {
        isUp = false;
        transform.localPosition = new Vector3(0, elevatorYDown, 0);
    }

    // Update is called once per frame
    void Update()
    {   //if 'E' has been pressed
        if (Input.GetKeyDown(KeyCode.E))
        {   //checking if isUP is true
            if (isUp)
            {
                isUp = false;
                //moves the elevator down
                transform.localPosition = new Vector3(0,elevatorYDown,0);
                playerManager.onElevatorToggle(upX, upY, downX, downY, true);
                levelManager.onElevatorToggle(elevatorPlatformUpX, downY, true);
            }
            else
            {
                isUp = true;
                //moves the elevator up
                transform.localPosition = new Vector3(0, elevatorYUp, 0);
                playerManager.onElevatorToggle(upX, upY, downX, downY, false);
                levelManager.onElevatorToggle(elevatorPlatformUpX, downY, false);
            }
        }
    }

    
}
