using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    LayerMask groundLayerMask;
    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");

    }





    public void FlipObject(bool flip)
    {
    
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    void DoRayCollisionCheck()
    {
        float rayLength = 0.2f; 

        Vector3 offset = new Vector3(0, -0.5f )


        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
        }
       
        Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor);

    }

    public LayerMask groundLayer;

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }



   

   








}


