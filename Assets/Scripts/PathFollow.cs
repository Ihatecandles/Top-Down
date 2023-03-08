using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathFollow : MonoBehaviour
{

    //GameObject[] waypoint;

     GameObject waypoint1;
     GameObject waypoint2;
     GameObject waypoint3;
     GameObject waypoint4;
     int currentwaypoint = 0;
     GameObject[] waypoints;

    UnityEngine.AI.NavMeshAgent agent;
    //public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        waypoint1 = GameObject.FindGameObjectWithTag("waypoint1");
        waypoint2 = GameObject.FindGameObjectWithTag("waypoint2");
        waypoint3 = GameObject.FindGameObjectWithTag("waypoint3");
        waypoint4 = GameObject.FindGameObjectWithTag("waypoint4");
        waypoints = new GameObject[] { waypoint1, waypoint2, waypoint3, waypoint4 };

    }



    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(agent.transform.position, waypoints[currentwaypoint].transform.position) >= 2)
        {

            agent.SetDestination(waypoints[currentwaypoint].transform.position);

        }

        else
        {
            currentwaypoint += 1;
            if(currentwaypoint == waypoints.Length)
            {
                currentwaypoint = 0;
            }
        }



    }

    
    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name);
        }
    }
    



}
