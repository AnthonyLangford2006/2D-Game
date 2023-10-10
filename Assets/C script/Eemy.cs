using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eemy : MonoBehaviour
{
    Helper helper;

    public GameObject player;
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<Helper>();

    }


    void Update()
    {
        if (Input.GetKey("space"))
        {
            helper.FlipObject(true);    // this will execute the method in HelperScript.cs
        }

        Vector3 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
            transform.position = new Vector2(transform.position.x + (1 * Time.deltaTime), transform.position.y);
        }

        if (player.transform.position.x < transform.position.x)
        {
            sr.flipX = false;
            transform.position = new Vector2(transform.position.x + (-1 * Time.deltaTime), transform.position.y);
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            Destroy(other.gameObject);


        }
    }
}