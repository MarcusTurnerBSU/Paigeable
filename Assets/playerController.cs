using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //referencing gameobject components
    public levelManager levelManager;
    public playerManager playerManager;

   
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
        movementComplete();
        yield return null;
    }

    public void moveRight()
    {
        Debug.Log("D pressed: " + this.name);
        if (levelManager.movementCheck(currentX, currentY, 1))
        {
            currentY++;
            transform.position += Vector3.right;
            Debug.Log("D pressed: ");
        }
        StartCoroutine(falling());
    }

    public void moveLeft()
    {
        Debug.Log("A pressed: " + this.name);
        if (levelManager.movementCheck(currentX, currentY, -1))
        {
            currentY--;
            transform.position += Vector3.left;
            Debug.Log("A pressed: ");
        }
        StartCoroutine(falling());
    }

    private void movementComplete()
    {
        playerManager.onControllerMovementComplete();
    }

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
