using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    public GameObject target;
    

    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.x>0 || movement.y > 0){
            animator.SetBool("isMoving", true);
        }
        else{
            animator.SetBool("isMoving", false);
        }

         
   }

    void FixedUpdate()
    {
        if(gameObject.tag == "Player") {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else{
            transform.position = Vector2.MoveTowards(transform.position,target.transform.position,3*Time.deltaTime);
        }

    }
        private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("GameOver");
            Destroy(gameObject);
        }
}
}
