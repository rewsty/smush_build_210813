using UnityEngine;
using System.Collections;

public class SpinningBlades : Loot 
{

	
	public float lifeSpan;
	
	void Start()
	{
		 
		
		if( !gameObject.active   )
		{
			
			gameObject.SetActive( true );
			
		}
		
		
		lootLifeSpan = lifeSpan;
		
		LifeCountDown();
	
	
	}
	
	
	void OnTriggerEnter( Collider other )
	{
		
		if( other.tag == Tags.player )
		{
		
			Debug.Log ( "Spinning Blades Active" );
			
			Messenger.Broadcast( "DeactivateBlades" );
			Messenger.Broadcast( "ActivateBlades" );
			
			//gameObject.SetActive( false );
			
			killSelf();
			
		}
		
		
	}
	

	
	
}
