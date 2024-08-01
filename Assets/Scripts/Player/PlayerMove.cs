using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed = 125f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //set rb to a Rigidbody on our player object.  
        // If there is no Rigidbody then we will get an error.
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody is not existing!");
        }
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // This method gets called when we are dragging the mouse over our palyer.
    private void OnMouseDrag()
    {
        //This turns our mouse pointer into usable 2D coordinates.
        Vector3 touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 manPosition = transform.position;  // This is current player position in coordinates.
        Vector2 directionToMove = new Vector2(0, 0);


            // if our mouse curser is above the player  
            if (manPosition.y < touchPoint.y)
            {
                //We are going up 
                directionToMove.y += touchPoint.y - manPosition.y;
            }
            else if (manPosition.y > touchPoint.y) // if the curser is below the player 
            {
                // we are going down 
                directionToMove.y -= manPosition.y - touchPoint.y;
            }
            if (manPosition.x < touchPoint.x)
            {
                //We are going right 
                directionToMove.x += touchPoint.x - manPosition.x;
            }
            else if (manPosition.x > touchPoint.x) // if the curser is left to the player 
            {
                // we are going left 
                directionToMove.x -= manPosition.x - touchPoint.x;
            }

        rb.velocity = new Vector2(0, 0);

        // Tells the rigidbody/Physics calculator to move us in the direction we want 
        rb.AddForce(directionToMove * movementSpeed, ForceMode2D.Force);

    }

    private void OnMouseDown()
    {
        rb.isKinematic = false; //Allow us to move the player.
    }

    // This function executes when you release the mouse.
    private void OnMouseUp()
    {
        rb.isKinematic = true;
        rb.velocity = new Vector2(0, 0); // To stop the player movement.
    }
}
