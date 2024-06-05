using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public float movePower = 5f;
    public float JumpPower = 10f;

    public int jumpCount = 0;
    Rigidbody2D rd;


    void Start()
    {
     rd = GetComponent<Rigidbody2D>();   
    }


    void Update()
    {
       Move();
       Jump();

    }
    void Jump() {
        // if(Input.GetKeyDown(KeyCode.Space)) {
        //     if(rd.velocity.y == 0) {
        //         rd.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        //     }
        // }
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < 2) {
            if(jumpCount < 2) {
                rd.velocity = Vector2.zero;
                rd.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                jumpCount++;
            }
            
        }
    }
    void Move() {
        // Vector3 moveVelocity = Vector3.zero;

        // if(Input.GetAxis("Horizontal") < 0) {
        //     moveVelocity = Vector3.left;
        // } else if(Input.GetAxis("Horizontal") > 0) {
        //     moveVelocity = Vector3.right;
        // }
        // transform.position += moveVelocity * movePower * Time.deltaTime;

        float move = Input.GetAxis("Horizontal");
        rd.velocity = new Vector2(move * movePower, rd.velocity.y);

    }
     void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Ground")) {
            Debug.Log("Ground");
            jumpCount = 0;
        }
    }
}
