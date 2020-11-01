using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Patrol : MonoBehaviour
{   
    public float speed; 
    private float waitTime;
    public float startWaitTime; 

    public Transform[] patrolPoints; 
    private int nextPoint; 


    // Start is called before the first frame update
    void Start()
    {
        nextPoint = 0;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[nextPoint].position, speed * UnityEngine.Time.deltaTime);

        if(Vector2.Distance(transform.position, patrolPoints[nextPoint].position) < 0.2f){
            if(waitTime <= 0){
                nextPoint = ((nextPoint+1) % patrolPoints.Length);
                waitTime = startWaitTime; 
            }
            else{
                waitTime -= UnityEngine.Time.deltaTime; 
            }
        }
		
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		SceneManager.LoadScene(2);
		print("oww");
	}
}
