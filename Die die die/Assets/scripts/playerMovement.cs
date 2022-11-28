using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;

    

    // Update is called once per frame

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (transform.hasChanged){
            animator.SetBool("isMoving",true);
            transform.hasChanged = false;
            }
        else{
            animator.SetBool("isMoving",false);
        }
        if(movement.x < 0){
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else{
            transform.eulerAngles = new Vector3(0,180,0);
        }
        if(Input.GetMouseButtonDown(0)){
            animator.SetTrigger("attack");
        }
        

   }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
        private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enemy")
        {
            Debug.Log("GameOver");
            Destroy(gameObject);
        }
}
}
