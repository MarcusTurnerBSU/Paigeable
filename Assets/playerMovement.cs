using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public levelManager levelManager;

   
    public Transform home;
    private Vector3 startingPosition;






    private void Awake()
    {
        startingPosition = transform.position;
        levelManager.onReset.AddListener(resetPosition);

    }
    private void OnDestroy()
    {
        levelManager.onReset.RemoveAllListeners();
    }

    private void resetPosition()
    {
        transform.position = startingPosition;
    }







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == home.position.x && transform.position.y == home.position.y)
        {
            //avatar is home - animation/well done message
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (levelManager.movementCheck(-1))
                {
                    transform.position += Vector3.left;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (levelManager.movementCheck(1))
                {
                    transform.position += Vector3.right;
                }
            }
        }
        //if avatar x and y is equal to home x and y {
        //stop movement/ show animation }
        //else { allow movement
        
    }








}
