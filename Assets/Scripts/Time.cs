using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time : MonoBehaviour
{
	public bool timeActive = true;
	public Text Timer;
	public float timeStart;
    // Start is called before the first frame update
    void Start()
    {
        Timer.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if(timeActive)
		{
			timeStart += UnityEngine.Time.deltaTime;
			Timer.text = timeStart.ToString("F2");
		}
    }
	public void stopTimer()
	{
		timeActive = false;
	}
}
