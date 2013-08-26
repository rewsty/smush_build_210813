/***
 * A script that manages the spinning blade power up .
***/



using UnityEngine;
using System.Collections;

public class SpinningBladeControl : MonoBehaviour 
{

	public GameObject spinningBlade;
	public int bladesLifeSpan = 5;
	
	private Transform player;
	private GameObject bladeClone;
	
	public static int bladeCount;
	
	private int _count;
	
	private bool _isOkToStop;
	
	void OnEnable()
	{
		//Listeners
		
		Messenger.AddListener( "ActivateBlades" , ActivateBlades );
		//Messenger.AddListener( "DeactivateBlades" , DeactivateBlades );
		Messenger.AddListener( "BladeCount" , BladeCount );
	
		
	}
	
	void OnDisable()
	{
		
		//Remove Listeners
		Messenger.RemoveListener( "ActivateBlades" , ActivateBlades );
		//Messenger.RemoveListener( "DeactivateBlades" , DeactivateBlades );
		Messenger.RemoveListener( "BladeCount" , BladeCount );

		
		
	}
	
	
	void Start()
	{
	
		//Check if the spinning blade object is attached.
		if( !spinningBlade )
		{
			
			Debug.Log ( "NO Blades PROP FOUND" );
			return;
			
		}
		
		
		//Find players transform
		player = GameObject.FindGameObjectWithTag( Tags.player ).gameObject.transform;
		
		
	}
	
	//Called when player walks over the spinning blades pickup
	//Starts the Blades co - routine
	public void ActivateBlades()
	{
	    
		_count = 0;
		//bladeCount = 0;
		Debug.Log ( "Activating Blades" );
		
		if( bladeClone )
		{
		
			KillBlade ();
			
			
			
		}
		
		
		StartCoroutine( "Blades" );
		
	}
	
	
	//Responsible for the Blades lifecycle.
	//Instantiates the blades and starts a count down . 
	private IEnumerator Blades()
	{
	
		Debug.Log ( "Blades Running" );
		
		
	
		bladeClone  =  ( GameObject ) Instantiate ( spinningBlade , player.position, player.rotation );
		
		bladeClone.gameObject.SetActive( true );
		
		
	
	    while( _count <= bladesLifeSpan )
		{
		
			yield return new WaitForSeconds( 1.0f );
			_count++;
			Debug.Log ( "Count " + _count );
		
			
		}
		
		
		Destroy ( bladeClone );
		
		_count = 0;
		
	}
	
	//Called when one of the spinning blades is destroyed. 
	//When count reaches 6 the spinnign blades object is destroyed and the co routine is stopped.
	void BladeCount()
	{
	
		bladeCount ++;
		Debug.Log ( "BladeCount " + bladeCount );
		if( bladeCount >= 6 )
		{
		
			//bladeClone.gameObject.SetActive( false );
			KillBlade ();
			bladeCount = 0;
			_count = 0;
			//_isOkToStop = true;
			
		}

		
		
	}
	
	//Stops the co routine and destroys the spinning blades gameobject.
	void KillBlade()
	{
	
		StopCoroutine( "Blades" );
		Destroy( bladeClone );
	
	}
	
	

}
