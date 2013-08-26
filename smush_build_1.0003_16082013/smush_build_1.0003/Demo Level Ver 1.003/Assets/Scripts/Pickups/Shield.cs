using UnityEngine;
using System.Collections;

public class Shield : Loot {

	public float lifeSpan;
	
	
	
	// Use this for initialization
	void Start () 
	{
	
		lootLifeSpan = lifeSpan;
		
		LifeCountDown();
		
		
	}
	
	
	void OnTriggerEnter( Collider other )
	{
		
		if( other.tag == Tags.player )
		{
		
			Debug.Log ( "Shield: Player Walked on me" );
			Messenger.Broadcast( "ActivateShield" );
			
			
			//gameObject.SetActive( false );
			
			killSelf();
			
		}
		
		
	}
	
	
	
	
	
}
