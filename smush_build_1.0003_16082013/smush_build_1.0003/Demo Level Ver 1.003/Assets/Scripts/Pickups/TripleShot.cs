using UnityEngine;
using System.Collections;

public class TripleShot : Loot 
{

	
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
		
			Debug.Log ( "Triple Shot: Player Walked on me" );
			//Messenger.Broadcast( "AddPlayer" );
			
			
			//gameObject.SetActive( false );
			
			killSelf();
			
		}
		
		
	}
	
	
}
