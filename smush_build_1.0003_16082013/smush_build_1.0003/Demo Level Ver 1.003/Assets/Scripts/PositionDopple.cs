using UnityEngine;
using System.Collections;

public class PositionDopple : MonoBehaviour {

	//public float rotationSpeed = 20.0f;
	
	public Transform player;
	public Transform myTransform;
	
	private float _x;
	private float _y;
	private float _z;
	
	private Vector3 _tmp;
	
	private Vector3 _offset;
	
	// Use this for initialization
	void Start () 
	{
	
		//Find players transform
		//player = GameObject.FindGameObjectWithTag( Tags.player ).gameObject.transform;
		
		myTransform = transform;
		
		if( !player )
		{
			Debug.Log ( "Position DOPPLE: player Not Found"   );
			return;
		}
			
		_offset = player.position - myTransform.position;
		
		Debug.Log ( " Offset  " + _offset );
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		myTransform.position = player.position - _offset;
		
	}
}
