using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Transform home;
    






    private void Awake()
    {
        
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
                transform.position += Vector3.left;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += Vector3.right;
            }
        }
        //if avatar x and y is equal to home x and y {
        //stop movement/ show animation }
        //else { allow movement
        
    }
    private void OnDestroy()
    {
        
    }








}
