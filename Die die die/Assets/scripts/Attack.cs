using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public Transform AttackPoint;
    public float attackRange;
     public LayerMask EnemyLayer;

     public float attackRate = 0.33f;
     public float nextAttackTime = 0f;

     private int hit = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Attacks();
                nextAttackTime = Time.time + attackRate;
            }
        }

    }

    void Attacks(){
        animator.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position,attackRange,EnemyLayer);
        foreach(Collider2D Enemy in hitEnemies){
            Enemy.GetComponent<EnemyController>().Damage(hit);
            Debug.Log("hit!");
        }

    }

    void OnDrawGizmosSelected() {
        if(AttackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(AttackPoint.position,attackRange);
    }
}
