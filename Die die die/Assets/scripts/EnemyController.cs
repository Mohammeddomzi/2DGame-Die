using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int MaxHealth = 100;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int health)
    {
        currentHealth -= health;
        
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }
}
