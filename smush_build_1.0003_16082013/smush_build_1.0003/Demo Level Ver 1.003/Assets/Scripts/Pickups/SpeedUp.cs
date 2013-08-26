using UnityEngine;
using System.Collections;

public class SpeedUp : Loot {

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
		
			Debug.Log ( "SpeedUp: Player Walked on me" );
			Messenger.Broadcast( "SpeedUp" );
			
			
			//gameObject.SetActive( false );
			
			killSelf();
			
		}
		
		
	}
	
	
}
