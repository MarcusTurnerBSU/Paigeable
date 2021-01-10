using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public levelManager levelManager;

   
    public Transform home;
    private Vector3 startingPosition;

    public int currentX, currentY;




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
        levelManager.allowInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelManager.allowInput)
            return;


        if (transform.position.x == home.position.x && transform.position.y == home.position.y)
        {
            //avatar is home - animation/well done message
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("A pressed: "+this.name);
                if (levelManager.movementCheck(currentX, currentY, -1))
                {
                    currentY--;
                    transform.position += Vector3.left;
                    Debug.Log("A pressed: ");
                }
                levelManager.allowInput = false;
                StartCoroutine(falling());
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("D pressed: "+this.name);
                if (levelManager.movementCheck(currentX, currentY, 1))
                {
                    currentY++;
                    transform.position += Vector3.right;
                    Debug.Log("D pressed: ");
                }
                levelManager.allowInput = false;
                StartCoroutine(falling());
            }
        }
        //if avatar x and y is equal to home x and y {
        //stop movement/ show animation }
        //else { allow movement
        
    }
    //using coroutine to show cube falling
    private IEnumerator falling()
    {
        yield return new WaitForSeconds(1f);
        while (levelManager.groundCheck(currentX, currentY))
        {
            currentX++;
            transform.position += Vector3.down;
            //show update every loop of the while
            yield return null;
            yield return new WaitForSeconds(1f);
        }
        levelManager.allowInput = true;
        yield return null;
    }






}
