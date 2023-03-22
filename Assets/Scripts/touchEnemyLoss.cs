using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class touchEnemyLoss : MonoBehaviour
{

    public bool touchingEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "laser-tag")
        {
            touchingEnemy = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "laser-tag")
        {
            touchingEnemy = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (touchingEnemy)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
