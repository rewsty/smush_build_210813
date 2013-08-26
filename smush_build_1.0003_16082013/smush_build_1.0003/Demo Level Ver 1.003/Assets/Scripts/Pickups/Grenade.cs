using UnityEngine;
using System.Collections;

public class Grenade : Loot 
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
		
			Debug.Log ( "Grenade :  Player Walked on me" );
			Messenger.Broadcast( "SelectWeapon" );
			
			
			//gameObject.SetActive( false );
			
			killSelf();
			
		}
		
		
	}
	

	
}
