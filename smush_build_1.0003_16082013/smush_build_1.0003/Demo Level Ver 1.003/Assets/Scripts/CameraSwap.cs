using UnityEngine;
using System.Collections;

public class CameraSwap : MonoBehaviour {

	
	public GameObject[] cameras;
	public int count;
	
	
	// Use this for initialization
	void Start () 
	{
		
		
		cameras = GameObject.FindGameObjectsWithTag( Tags.camera );
		
		
		if( cameras.Length > 0 )
		{
		
			//Set Default Camera View
			cameras[ 0 ].SetActive( true );
		
		}
		else
		{
		
			Debug.Log ( "No Cameras Found" );
			return;
			
		}
		
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
		if( Input.GetKeyDown( KeyCode.X ) )
		{
		
			
			SwapCamera( count );
			count++;
			
			if( count >= cameras.Length )
			{
			
				count = 0;
				
			}
			
			
		}
		
		
		
	
	}
	
	void SwapCamera( int  currentCamera )
	{
		
		for( int x = 0;  x < cameras.Length; x++ )
		{
			
			cameras[ x ].SetActive( false );
			
				
		}
		
		
		
		cameras[ currentCamera ].SetActive( true );
			
			
			
			
	}
}
