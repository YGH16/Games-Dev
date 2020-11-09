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

    private Vector3 direction; 

    [SerializeField] private Transform pffieldOfView; 
    [SerializeField] private float fov = 50f;
    [SerializeField] private float viewDistance = 7f;
    private FieldOfView fieldOfView;

    // Start is called before the first frame update
    void Start()
    {
        nextPoint = 0;
        direction = (patrolPoints[nextPoint].position - transform.position).normalized;
        fieldOfView = Instantiate(pffieldOfView, null).GetComponent<FieldOfView>();

        fieldOfView.SetFoV(fov); 
        fieldOfView.SetViewDistance(viewDistance);
    }   

    // Update is called once per frame
    void Update()
    {
        fieldOfView.SetDirection(direction); 
        fieldOfView.SetOrigin(transform.position); 

        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[nextPoint].position, speed * UnityEngine.Time.deltaTime);
        if(Vector2.Distance(transform.position, patrolPoints[nextPoint].position) < 0.2f){
            if(waitTime <= 0){
                nextPoint = ((nextPoint+1) % patrolPoints.Length);
                waitTime = startWaitTime;
                direction = (patrolPoints[nextPoint].position - transform.position).normalized;  
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
