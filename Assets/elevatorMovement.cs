using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorMovement : MonoBehaviour
{

    public float elevatorYUp, elevatorYDown;
    private bool isUp = false;  

    // Start is called before the first frame update
    void Start()
    {
        isUp = false;
        transform.localPosition = new Vector3(0, elevatorYDown, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isUp)
            {
                isUp = false;
                transform.localPosition = new Vector3(0,elevatorYDown,0);
            }
            else
            {
                isUp = true;
                transform.localPosition = new Vector3(0, elevatorYUp, 0);
            }
        }
    }

    
}
