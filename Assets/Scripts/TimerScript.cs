using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
	public GameObject spawner;
	public float timeStart = 60;
	public Text textBox;
	private float timeLastSpawned;
	private bool startCheck = false;

	// Use this for initialization
	void Start()
	{
		
	}

	public void startTime()
    {
		timeLastSpawned = 0;
		startCheck = true;
    }
	// Update is called once per frame
	void Update()
	{
		timeStart -= Time.deltaTime;
		
		if (Time.time-timeLastSpawned >= 2 && startCheck)
        {
			spawner.GetComponent<createEnemy>().createSpawn();
			timeLastSpawned = Time.time;
		}
		
		
		//textBox.text = Mathf.Round(timeStart).ToString();
	}
}