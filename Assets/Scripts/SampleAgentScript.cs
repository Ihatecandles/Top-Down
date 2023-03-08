using UnityEngine;
using System.Collections;

public class SampleAgentScript : MonoBehaviour
{
	public Transform target;
	UnityEngine.AI.NavMeshAgent agent;

	void Start ()
	{
	// define our Agent
	agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Update ()
	{
	// set the destination of our Agent to 'target'
	agent.SetDestination(target.position);
	//agent.transform.LookAt(target);
	//agent.transform.Rotate(0,180,0);
	//agent.transform.Translate(Vector3.forward*Time.deltaTime*5);
	}
}
