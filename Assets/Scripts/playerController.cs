using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //referencing gameobject components
    public levelManager levelManager;
    public playerManager playerManager;
  
    private Vector3 startingPosition;

    public int currentX, currentY;
    public bool isHome;
    public char homeID;
    private int startingX, startingY;

    //awake is being called when the script is being loaded
    private void Awake()
    {
        startingPosition = transform.position;
        startingX = currentX;
        startingY = currentY;
    }

    //reset method is resetting the avatar's position
    public void Reset()
    {
        transform.position = startingPosition;
        currentX = startingX;
        currentY = startingY;
        isHome = false;
    }


    //using coroutine to show cube falling
    private IEnumerator falling()
    {
        yield return new WaitForSeconds(0.1f);
        while (levelManager.groundCheck(currentX, currentY))
        {
            currentX++;
            transform.position += Vector3.down;
            //show update every loop of the while
            yield return null;
            yield return new WaitForSeconds(0.1f);
        }
        movementComplete();
        yield return null;
    }

    public void moveRight()
    {
        //if this player is home, block movement
        if (isHome)
        {
            movementComplete();
            //Debug.Log(this.name + "! isHome: X: " + currentX + ", Y: " + currentY);
            return;
        }
        
        //checking if player can move from current position to direction right
        if (levelManager.movementCheck(currentX, currentY, 1))
        {
            //updating current position 
            currentY++;
            //updating the objects visuals on the screen
            transform.position += Vector3.right;
            //storing if player's new current position is equal to home or not
            isHome = levelManager.homeCheck(currentX, currentY, homeID);
            //Debug.Log(this.name + "! moveCheck: X: " + currentX + ", Y: " + currentY + ", isHome: " + isHome.ToString());
        }
        //call coroutine to check/start falling
        StartCoroutine(falling());
    }

    public void moveLeft()
    {
        if (isHome)
        {
            //Debug.Log(this.name + "! isHome: X: " + currentX + ", Y: " + currentY);
            movementComplete();
            return;
        }

        if (levelManager.movementCheck(currentX, currentY, -1))
        {
            currentY--;
            transform.position += Vector3.left;
            isHome = levelManager.homeCheck(currentX, currentY, homeID);
            //Debug.Log(this.name + "! moveCheck: X: " + currentX + ", Y: " + currentY + ", isHome: " + isHome.ToString());
        }
        StartCoroutine(falling());
    }

    //telling playerManager avatar has completed it's move
    private void movementComplete()
    {
        playerManager.onControllerMovementComplete();
    }

    //elevator platform moves up
    public void moveUp()
    {
        transform.position += Vector3.up * 2;
        currentX -= 2;
    } 

    public void moveDown()
    {
        transform.position -= Vector3.up * 2;
        currentX += 2;
    }

    
}
