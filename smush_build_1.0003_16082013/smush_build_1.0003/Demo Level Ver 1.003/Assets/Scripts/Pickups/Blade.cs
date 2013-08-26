using UnityEngine;
using System.Collections;

public class Blade : MonoBehaviour {

	
	private float _damageAmount = 200;
	
	public int hitCount = 20;
	private int tmp;
	
	void Start()
	{
	
		
		tmp = hitCount;
		//gameObject.SetActive( true );
		
		
	}
	
	
	void OnTriggerEnter( Collider other )
	{
	
		Debug.Log ( "Blade" );
		
		if( other.tag == Tags.enemy )
		{
		
			Messenger.Broadcast<float>( other.gameObject  ,  "Damage" , _damageAmount);
		
			
			hitCount --;
			
			if( hitCount <= 0 )
			{
				
				Messenger.Broadcast ( "BladeCount" );
				
				gameObject.SetActive( false );
				
			    hitCount = tmp;
				
			}
		}
		
		
		
	}
	
	
	
	
	
	
}
