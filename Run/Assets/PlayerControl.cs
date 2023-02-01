using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public float speed = 10.0f;
    private Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.CompareTag("Enemy")){
            GetComponent<AudioSource>().Play();
            Application.Quit();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb.velocity;
        if(Input.GetKey(moveUp)){
            vel.y = speed;
        }
        else if(Input.GetKey(moveDown)){
            vel.y = -speed;
        }
        else if(Input.GetKey(moveLeft)){
            vel.x = -speed;
        }
        else if(Input.GetKey(moveRight)){
            vel.x = speed;
        }
        else{
            vel.x=0;
            vel.y=0;
        }
        rb.velocity = vel;
    }
}
