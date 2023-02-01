using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = .5f;
    private Transform tran;
    
    private void OnTriggerEnter2D(Collider2D o){
        if(o.gameObject.tag == "Player"){
            tran = o.transform;
        }
    }
    
    void Update()
    {
        if(tran != null){
            float move = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, tran.position, move);
        }
    }
}
