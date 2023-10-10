using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScript : MonoBehaviour
{
    SpriteRenderer sr;
   [SerializeField] Transform groundCheckCollider;
   [SerializeField] LayerMask groundLayer;
    const float groundCheckRadius = 0.2f;
    bool isGrounded = false;


    Animator anim;

    float speed = 3.5f;
    // Start is called before the first frame update
    Rigidbody2D rb;

    void Start()
    {
        print("start");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Helper = gameObject.AddComponent<Helper>
    }


    // Update is called once per frame
    void Update()
    {
        
        int jumpAmount = 5;
        anim.SetBool("Warrior Run", false);
        anim.SetBool("Warrior Jump", false);



        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            print("Player pressed space");
            transform.position = new Vector2(transform.position.x + (1 * Time.deltaTime), transform.position.y);
            anim.SetBool("Warrior Jump", true);

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            print("player pressed attack");
            anim.SetTrigger("Warrior Attack");
        }



            DoRun();
           GroundCheck();
          


    }

    void DoRun()
    {
        if (Input.GetKey("left") == true)
        {
            int speed = 4;
            print("Player pressed left");
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("Warrior Run", true);
            sr.flipX = true;
        }

        if (Input.GetKey("right") == true)
        {
            int speed = 4;
            anim.speed = 2;
            print("Player pressed right");
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("Warrior Run", true);
            sr.flipX = false;
        }
    }


    void GroundCheck()
    {
        isGrounded = false;

        //Check if the GroundCheckObject is colliding with other
        //2D Colliders that are in the "Ground" Layer
        //If yes (isGrounded true) else (isGrounded false)
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
            isGrounded = true;
     
    }

    private void OnCollisionEnter( Collider2D other )
    {

    }








}
