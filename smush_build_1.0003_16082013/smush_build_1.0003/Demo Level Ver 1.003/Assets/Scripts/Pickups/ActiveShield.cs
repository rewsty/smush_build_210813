using UnityEngine;
using System.Collections;

public class ActiveShield : MonoBehaviour 
{

	public float damageAmount;
	
	void OnTriggerEnter( Collider other )
	{
	
		if( other.tag == Tags.enemy )
		{
		
			Debug.Log ( "Active Shield: Hit Enemy" );
			Messenger.Broadcast<float>( other.gameObject  ,  "Damage" , damageAmount);
			
		}
		
		
	}
	
	
	
}
