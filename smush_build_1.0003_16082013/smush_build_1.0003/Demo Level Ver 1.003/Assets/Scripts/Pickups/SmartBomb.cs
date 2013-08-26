using UnityEngine;
using System.Collections;

public class SmartBomb : Loot 
{
	
	
	public float lifeSpan;
	
	public float damageAmount;
	

	
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
		
			Debug.Log ( "Smart BOMB :Player Walked on me" );
			Messenger.Broadcast<float>( "Damage1" , 200);
			
			
			//gameObject.SetActive( false );
			
			
			killSelf();
			
		}
		
		
	}
	
	
}
