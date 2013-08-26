using UnityEngine;
using System.Collections;

public class CheckEnemyRange : MonoBehaviour 
{
	
	
	void OnTriggerEnter( Collider other )
	{
		
		if( other.tag == Tags.enemy )
		{
		
			
			Debug.Log ( "Enemy Passed" );
			
			Messenger.Broadcast( other.gameObject,  "RangeCheck" );
			
			
		}
	
		
	}
	
	
	

}
