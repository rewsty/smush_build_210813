using UnityEngine;
using System.Collections;

public class ShieldControl : MonoBehaviour 
{
	
	public GameObject shield;
	private Transform player;
	public int shieldLife = 15;
	
	private int _count = 0;
	
	void OnEnable()
	{
		//Listeners
		Messenger.AddListener( "ActivateShield" , ActivateShield );
	
		
	}
	
	void OnDisable()
	{
		
		//Remove Listeners
	    Messenger.RemoveListener( "ActivateShield" , ActivateShield );
		
	}
	
	void Start()
	{
	
		
		
		shield.gameObject.SetActive( false );
		
	}
	
	public void ActivateShield()
	{
	
		
		if( shield.gameObject.active )
		{
		
			Debug.Log ( "Killing Shield" );
			StopCoroutine( "Shield" );
			_count = 0;
		}
		
		
		Debug.Log ( "Generating Shield" );
	   
		shield.gameObject.SetActive( true );
		StartCoroutine( "Shield" );
	
	}
	
	
	IEnumerator Shield()
	{
	
		
		shield.gameObject.SetActive( true );
		while( _count <= shieldLife )
		{
		
			yield return new WaitForSeconds( 1.0f );
			_count++;
			
			Debug.Log( " Shield Count: " + _count );
		    
			
		}
		
		shield.gameObject.SetActive( false );
		Debug.Log ( "FINISHED" );
		_count = 0;
	}
	
	
	
}
