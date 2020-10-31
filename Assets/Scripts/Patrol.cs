using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        nextPoint = 0 % patrolPoints.Length;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[nextPoint].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, patrolPoints[nextPoint].position) < 0.2f){
            if(waitTime <= 0){
                nextPoint = (nextPoint+1) % patrolPoints.Length;
                waitTime = startWaitTime; 
            }
            else{
                waitTime -= Time.deltaTime; 
            }
        }
    }
}
