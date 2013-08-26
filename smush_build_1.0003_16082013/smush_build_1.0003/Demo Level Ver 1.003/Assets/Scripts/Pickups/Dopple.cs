using UnityEngine;
using System.Collections;

public class Dopple : Loot 
{
	
	public float lifeSpan;
	
	
	void Start()
	{
		 
		lootLifeSpan = lifeSpan;
		
		LifeCountDown();
	
	
	}
	
	
	void OnTriggerEnter( Collider other )
	{
		
		if( other.tag == Tags.player )
		{
		
			Debug.Log ( "DOPPLE ACTIVATED" );
			Messenger.Broadcast( "ActivateDopple" );
			
			
			//gameObject.SetActive( false );
			
			killSelf();
			
		}
		
		
	}
	
}
