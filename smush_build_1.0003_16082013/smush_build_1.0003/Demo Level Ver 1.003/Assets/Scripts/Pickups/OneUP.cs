using UnityEngine;
using System.Collections;

public class OneUP : Loot
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
		
			Debug.Log ( "Player Walked on me" );
			Messenger.Broadcast( "AddPlayer" );
			
			
			//gameObject.SetActive( false );
			
			killSelf();
			
		}
		
		
	}
	

	

}
