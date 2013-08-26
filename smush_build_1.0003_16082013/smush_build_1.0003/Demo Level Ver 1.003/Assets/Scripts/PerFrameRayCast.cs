using UnityEngine;
using System.Collections;

public class PerFrameRayCast : MonoBehaviour {
	
	
	private RaycastHit hitInfo;
    private Transform myTransform;

	
    void Awake()
	{
	
		myTransform = transform;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		// Cast a ray to find out the end point of the laser
	  // hitInfo = new RaycastHit();
	  // Physics.Raycast (myTransform.position, myTransform.forward, out  hitInfo);
		
		
	}
	
	
	public RaycastHit GetHitInfo ()
	{
		
		
		Debug.Log ( "GETINFO" );
		// Cast a ray to find out the end point of the laser
	    hitInfo = new RaycastHit();
	    Physics.Raycast (myTransform.position, myTransform.forward, out  hitInfo);
		
		if( hitInfo.transform )
		{
			
			Debug.Log ( "JUST SHOT: " +  hitInfo.transform.name );	
		
		
		}
		else
		{
			
			Debug.Log ( "Hit Nothing" );	
		
		}
			
		
		
		return hitInfo;
	}

	
}
