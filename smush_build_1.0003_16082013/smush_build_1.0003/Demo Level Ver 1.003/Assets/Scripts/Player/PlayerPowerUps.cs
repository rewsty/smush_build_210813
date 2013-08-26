using UnityEngine;
using System.Collections;

public class PlayerPowerUps : MonoBehaviour {

	
	
	
	
	public int speedUpDuration = 15;
	public int shieldLife = 15;
	
	public int bladesLife = 15;
	public GameObject[] blades;
	public static int bladeCount;
	public GameObject shield;
	public GameObject spinningBlade;
	
	private GameObject player;
	
	void OnEnable()
	{
	
		Messenger.AddListener( "ActivateShield" , ActivateShield );
		Messenger.AddListener( "ActivateBlades" , ActivateBlades );
		Messenger.AddListener( "DeactivateBlades" , DeactivateBlades );
		Messenger.AddListener( "BladeCount" , BladeCount );
	
		
	}
	
	void OnDisable()
	{
		
		Messenger.RemoveListener( "ActivateShield" , ActivateShield );
		Messenger.RemoveListener( "ActivateBlades" , ActivateBlades );
		Messenger.RemoveListener( "DeactivateBlades" , DeactivateBlades );
		Messenger.RemoveListener( "BladeCount" , BladeCount );

		
		
	}
	
	
	
	void Start () 
	{
	
		
	  
		blades = GameObject.FindGameObjectsWithTag( Tags.blade );
		
		
		
		
		player = GameObject.FindGameObjectWithTag( Tags.player );
		
		if( !spinningBlade )
		{
			
			Debug.Log ( "NO Blades PROP FOUND" );
			return;
			
		}
		
		
		if( !shield )
		{
			
			Debug.Log ( "NO SHIELD PROP FOUND" );
			return;
			
		}
		
		if( !player )
		{
			
			Debug.Log ( "NO PLAYER FOUND" );
			return;
			
		}
		
		
		
		spinningBlade.gameObject.SetActive( false );
		shield.gameObject.SetActive( false );
		
		
	}
	
	#region Shield Code
	public void ActivateShield()
	{
	
		Debug.Log ( "Generating Shield" );
	
		//shield.gameObject.SetActive( true );
		StartCoroutine( "Shield" );
	
	}
		
	IEnumerator Shield()
	{
	
		int count = 0; 
		shield.gameObject.SetActive( true );
		while( count <= shieldLife )
		{
		
			yield return new WaitForSeconds( 1.0f );
			count++;
			
		
			
		}
		
		shield.gameObject.SetActive( false );
		
	}
	#endregion
	
	
	#region Spinning Blades Code
	//Spinning Blades Code
	public void ActivateBlades()
	{
	    bladeCount = 0;
		Debug.Log ( "Activating Blades" );
		StartCoroutine( "Blades" );
		
	}
	
	public void DeactivateBlades()
	{
	
		StopCoroutine( "Blades" );
		
	}
		
	private IEnumerator Blades()
	{
	
		Debug.Log ( "Blades Running" );
		int count = 0; 
		
	
		spinningBlade.gameObject.SetActive( true );
		
		
	
		for( int i = 0; i < blades.Length; i++ )
		{
		
			if( blades[i].gameObject.active == false )
			
			blades[ i ].gameObject.SetActive( true );
			
		}
		
		
		while( count <= bladesLife )
		{
		
			yield return new WaitForSeconds( 1.0f );
			count++;
			
		
			
		}
		
		
		//Destroy( spinningBlade );
		
		spinningBlade.gameObject.SetActive( false );
		count = 0;
		
	}
	
	
	void BladeCount()
	{
	
		bladeCount ++;
		
		if( bladeCount >= 6 )
		{
		
			spinningBlade.gameObject.SetActive( false );
			bladeCount = 0;
		}

		
		
	}
	
	
	
	//Spinning Blades Code ends
	#endregion
	
	
}
