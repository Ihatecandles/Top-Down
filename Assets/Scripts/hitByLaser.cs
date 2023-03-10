using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitByLaser : MonoBehaviour
{
    public int timesHit;
    // Start is called before the first frame update
    void Start()
    {
        timesHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void eatLaser()
    {
        timesHit++;
    }
}
