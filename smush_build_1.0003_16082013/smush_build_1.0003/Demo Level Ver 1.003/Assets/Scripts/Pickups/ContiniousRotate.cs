using UnityEngine;
using System.Collections;

public class ContiniousRotate : MonoBehaviour {

	
	public float rotationSpeed = 20.0f;
	
	public GameObject player;
	public Transform myTransform;
	
	
	
	// Use this for initialization
	void Start () 
	{
	
		
		
		player = GameObject.FindGameObjectWithTag( Tags.player );
		
		if( !player )
		{
		
			Debug.Log( "Player Not Found" );
			return;
			
		}
		
		myTransform = transform;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		myTransform.position = player.transform.position;
		
		transform.Rotate( Vector3.up , Time.deltaTime * rotationSpeed );
		
	}
}
