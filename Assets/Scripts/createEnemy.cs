using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createEnemy : MonoBehaviour
{

    public GameObject EnemySpawn; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void createSpawn()
    {
        
        Instantiate(EnemySpawn, new Vector3((float)1.5, (float)1.5, (float)Random.Range(-1, -11)), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
