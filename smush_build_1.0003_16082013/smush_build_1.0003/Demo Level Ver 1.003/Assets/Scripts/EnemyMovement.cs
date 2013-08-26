using UnityEngine;
using System.Collections;


//TEST
public class EnemyMovement : MonoBehaviour 
{
	
	
	public Transform target;
	Transform myTransform;
	
	public float moveSpeed;
	public float rotationSpeed;
	
	Quaternion angle;
	
	void Awake()
	{
	
	  myTransform = transform;
	
	}
	
	// Use this for initialization
	void Start () 
	{
	
		
		target = GameObject.FindWithTag( "Player" ).transform;
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
		
		
		GetComponent<NavMeshAgent>().destination = target.position;
		
		
	/*	if( target.transform )
		{
			
			//Rotate to look at the player
			
			angle = Quaternion.LookRotation( target.position - myTransform.position );
			
			myTransform.rotation = Quaternion.Slerp ( myTransform.rotation, angle , rotationSpeed*Time.deltaTime );	
			
			
	       //Move towards the player
		   myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		
		
		}*/
		
		
		
		
		
	
	}
}
