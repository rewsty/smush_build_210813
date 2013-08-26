using UnityEngine;
using System.Collections;

public class DoppleGangerControl : MonoBehaviour 
{

	
	public GameObject doppleGanger;
	
	public int lifeSpan = 30;
	
	private Transform player;
	
	private Transform myTransform;
	
	private Transform temp;
	
	
	private int _count;
	
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
	
		
		if( !doppleGanger )
		{
		
			Debug.Log ( "DoppleGanger OBject Not Found" );
			return;
			
		}
		
		
		doppleGanger.SetActive( false );
		myTransform = transform;
		
		//Find players transform
		player = GameObject.FindGameObjectWithTag( Tags.player ).gameObject.transform;
	 
		if( !player )
		{
		
			Debug.Log ( "NO Player Found" );
			return;
		}
	}
	

	
	public void ActivateDopple()
	{
	    
		
		if(  doppleGanger.gameObject.active )
		{
		
			Debug.Log ( "Killing Dopple" );
			StopCoroutine( "Dopple" );
			_count = 0;
		}
		
		
		
		
		gameObject.SetActive( true );
		StartCoroutine( "Dopple" );
		
	}
	
	
	private IEnumerator Dopple()
	{
	
	    doppleGanger.gameObject.SetActive( true );
		
		while( _count < lifeSpan )
		{
		
			yield return new WaitForSeconds( 1.0f );
			_count++;
			
			Debug.Log( " Dopple Count: " + _count );
			
		}
		
		doppleGanger.gameObject.SetActive( false );
		_count = 0;
		
	}



}
