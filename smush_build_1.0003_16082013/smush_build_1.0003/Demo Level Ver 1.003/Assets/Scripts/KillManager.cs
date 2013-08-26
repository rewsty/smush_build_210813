using UnityEngine;
using System.Collections;

public class KillManager : MonoBehaviour 
{
	
	public GameObject detonator;
	public GameObject[] killList;
	
	
	public int scoreValue;
	
	
	void OnEnable()
	{
	
		Messenger.AddListener( "KillAll" , KillAll );
		
	}
	
	void OnDisable()
	{
		
		Messenger.RemoveListener( "KillAll" , KillAll );
		
	}
	
	
	public void KillAll()
	{
		
		
		int totalScore = 0;
		Debug.Log ( "Kill All Called" );
		
		killList =  GameObject.FindGameObjectsWithTag( Tags.enemy );
		
		for( int i = 0; i < killList.Length; i++ )
		{
		
			if( killList[i].active )
			{
			
				Debug.Log ( "Found Active Enemy" );
				
				
				
				totalScore = totalScore + scoreValue; 
				//killList[i].SetActive( false );
				
			   // Instantiate ( detonator, killList[i].transform.position, killList[i].transform.rotation );
				Destroy ( killList[i].gameObject );
				
				
			}
			
			
			
		}
		
		
		Messenger.Broadcast<int>( "ManageScore", totalScore );
		
	
		
		
	}
	
	
}
