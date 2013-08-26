using UnityEngine;
using System.Collections;

public class RotateWithKeys : MonoBehaviour {

	
	public float m_VerticalAxis;
	public float m_HorizontalAxis;
	
	
	public Vector3 m_Rotation;
	
	// Use this for initialization
	void Start () 
	{
	
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		//Read Input Every Frame
		m_Rotation = new Vector3( Input.GetAxis( "Horizontal_R" ), 0.0f, Input.GetAxis ( "Vertical_R" ) );
		
		
		//Only Do work if meaningful
		
		if( m_Rotation.sqrMagnitude < 0.1f )
		{
		
			return;
		}
		
		//Set our rotation to represent the input.
		
		//m_Rotation.Normalize();
		
	
	
	    // Apply the transform to the object		
		transform.rotation = Quaternion.LookRotation( m_Rotation );
	
	
	}
}
