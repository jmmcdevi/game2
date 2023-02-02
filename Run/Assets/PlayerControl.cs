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
    bool alive = true;

    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.CompareTag("Enemy")){
            alive = false;
            GetComponent<AudioSource>().Play();
            rb.velocity = Vector2.zero;
            Reset();
        }
    }

    void Reset(){
        alive = true;
        rb.velocity = Vector2.zero;
        transform.position = new Vector3(0f, -3.5f, -1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alive == true){
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
}
