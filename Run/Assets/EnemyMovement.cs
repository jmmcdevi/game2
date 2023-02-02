using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = .5f;
    private Transform tran;
    private Rigidbody2D rb;
    private bool check = true;

    void Reset(){
        rb.velocity = Vector2.zero;
        check = true;
        transform.position = new Vector3(0f, 4f, -1f);
    }

    private void OnTriggerEnter2D(Collider2D o){
        if(o.gameObject.tag == "Player"){
            tran = o.transform;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D o){
        if(o.gameObject.tag == "Player"){
            rb.velocity = Vector2.zero;
            check = false;
            Reset();
        }
    }

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(tran != null & check==true){
            float move = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, tran.position, move);
        }
        else{
            rb.velocity = Vector2.zero;
        }
    }
}
