using UnityEngine;
using System.Collections;

public class MatchPosition : MonoBehaviour {

	public float rotationSpeed = 20.0f;
	
	private Transform player;
	public Transform myTransform;
	
	
	
	
	// Use this for initialization
	void Start () 
	{
	   //Find players transform
		player = GameObject.FindGameObjectWithTag( Tags.player ).gameObject.transform;
		
		if( !player )
		{
			Debug.Log ( "Class Match Position: player Not Found"   );
			return;
		}
		
		
		
		myTransform = transform;
		
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
	
		
		
		myTransform.position = player.position;
		
	
		
	}
}
