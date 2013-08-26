using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{

	public GameObject enemyObject;
	public int minNumEnemies;
	public int maxNumEnemies;
	
	void OnEnable()
	{
	
		//Add Listeners here
		Messenger.AddListener( gameObject,"SpawnEnemy" , SpawnEnemy );
	
			
		
	}
	
	void OnDisable()
	{
		
	
		//Remove  Listeners
		Messenger.RemoveListener( gameObject, "SpawnEnemy" , SpawnEnemy );
	}
	
	
	public void SpawnEnemy()
	{
	
		int numEnemies = 0;
		
		numEnemies = Random.Range ( minNumEnemies , maxNumEnemies );
		
		
		Messenger.Broadcast<int>( "CountEnemies" , numEnemies );
		
		if( enemyObject )
		{
			
			Debug.Log ( "Spawner Called" );
			
			for( int i = 0; i < numEnemies; i++ )
			{
			
				Instantiate ( enemyObject, transform.position, transform.rotation );
			
			}
				
		}
	
	}
	
	
}
