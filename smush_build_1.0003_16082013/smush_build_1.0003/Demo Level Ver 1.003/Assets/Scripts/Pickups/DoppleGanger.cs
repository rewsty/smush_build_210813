using UnityEngine;
using System.Collections;

public class DoppleGanger : MonoBehaviour 
{
	
	public int lifeSpan = 30;
	
	private Transform player;
	
	private Transform myTransform;
	
	private Transform temp;
	
	
	
	
	void OnEnable()
	{
	
		Messenger.AddListener( "ActivateDopple" , ActivateDopple );
		
	}
	
	void OnDisable()
	{
		
		Messenger.RemoveListener( "ActivateDopple" , ActivateDopple );
		
	}
	
	
	
	
	// Use this for initialization
	void Start () 
	{
	
		gameObject.SetActive( true );
		myTransform = transform;
		
		//Find players transform
		player = GameObject.FindGameObjectWithTag( Tags.player ).gameObject.transform;
	 
		if( !player )
		{
		
			Debug.Log ( "NO Player Found" );
			return;
		}
	}
	
	
		// Update is called once per frame
	void LateUpdate () 
	{
	
		float x = 0.0f;
		float y = 0.0f;
		float z = 0.0f;
		
		
		
		x = player.position.x + 30;
		y = player.position.y;
		z = player.position.z + 30;
	
		
		myTransform.position = new Vector3( x, y, z );
		
	
		
	}
	
	public void ActivateDopple()
	{
	    gameObject.SetActive( true );
		StartCoroutine( "Dopple" );
		
	}
	
	
	private IEnumerator Dopple()
	{
	
		int count = 0; 
		
		
		
		while( count <= lifeSpan )
		{
		
			yield return new WaitForSeconds( 1.0f );
			count++;
			
			
			
		}
		
		gameObject.SetActive( false );
		
		
	}
	
}
