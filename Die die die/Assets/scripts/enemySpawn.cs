using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public float timer = 0;
    public float start = 10f;
    
    private int random;
    void Start()
    {
        timer = start;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1 *Time.deltaTime;
        if(timer <= 0) {
            for(int i = 0; i < 3; i++) {
                random = Random.Range(0,30);
                Instantiate(enemies[26],new Vector3(Random.Range(-9,10),Random.Range(-5,6),0),Quaternion.identity);
            }
            timer = start;
        }
    }
}
