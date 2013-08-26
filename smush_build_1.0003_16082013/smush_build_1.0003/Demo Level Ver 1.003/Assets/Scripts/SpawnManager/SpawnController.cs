using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour 
{
	
	public GameObject[] spawnPoints; //collection of spawnpoints
	public int randomSpawnPoint;
	
   	public Transform playerTransform;
	
	
   	public int activeEnemies = 0;
   	public int maxActiveEnemies = 3;
	
   	public int maxEnemiesForLevel = 2000;
	
   	public int totalEnemyCount = 0;
	
  	public bool isLevelOver = false;
	
		
  	public int lastSpawnPoint = 0;
  	public int random = 0;
	
   	public int enemySpawnDelay = 0;
   	public int count = 0;
	
	
	public float minSpawnTime = 5;
	public float maxSpawnTime = 15;
	

	
	
	void OnEnable()
	{
	
		//Add Listeners here
		Messenger.AddListener<int>( "CountEnemies" , CountEnemies );
		
			
		
	}
	
	void OnDisable()
	{
		
	
		//Remove  Listeners
		Messenger.RemoveListener<int>( "CountEnemies" , CountEnemies );
		
	}
	
	
	
	// Use this for initialization
	void Start () 
	{
	
	
		spawnPoints = GameObject.FindGameObjectsWithTag( Tags.spawnPoints );
		//SpawnRandomEnemy();
		
		playerTransform = GameObject.FindGameObjectWithTag( Tags.player ).transform;
		
		
		StartCoroutine( "SpawnEnemy" );
		
	
	
	}
	

	public void CountEnemies( int numEnemies )
	{
	
		totalEnemyCount = totalEnemyCount + numEnemies;
		
		
		if( totalEnemyCount >= maxEnemiesForLevel )
		{
			isLevelOver = true;
		}
		
	}
	
	
	
	public int RandomSpawnPoint()
	{
	
		
		
		//Decide which spawnpoint to use.
		randomSpawnPoint = Random.Range( 0 , spawnPoints.Length  );
		
		//Make sure that the enemy does not spawn on the same spawn point twice in a row
		if( randomSpawnPoint == lastSpawnPoint )
		{
		
				randomSpawnPoint  = ( randomSpawnPoint + 1 ) % spawnPoints.Length; //Randomly pick a spawnpoint
					
		}
		
		lastSpawnPoint = randomSpawnPoint;
		
		return randomSpawnPoint;
		
		
	}
	
	
	
	
	public IEnumerator SpawnEnemy( )
	{
		
		    float delay;
		    int randomSpawn;
		    
		
			while( !isLevelOver )
			{
		    
				if( spawnPoints.Length <= 0 )
				{
					return false;
				}
			
		    	delay = Random.Range( minSpawnTime , maxSpawnTime );
		
		    	randomSpawn = RandomSpawnPoint();
		
				//spawnPoints[ randomSpawnPoint ].GetComponent<Spawner>().SpawnEnemy();
		        Messenger.Broadcast ( spawnPoints[ randomSpawn ].gameObject, "SpawnEnemy" );
		
				//wait for the time defined at the delay parameter    
			    yield return new WaitForSeconds( delay );
		
			}
	}
	/*
	public void SpawnRandomEnemy()
	{
	
		
	    Debug.Log ( spawnPoints.Length  );
		randomSpawnpoint = Random.Range( 0 , spawnPoints.Length - 1 );
		
		
		float playerDistance = Vector3.Distance( playerTransform.position, spawnPoints[ randomSpawnpoint ].transform.position );
		
		
		
		
		if( playerDistance > minDistance && playerDistance < maxDistance )
		{
			
			spawnPoints[ randomSpawnpoint ].GetComponent<Spawner>().SpawnEnemy();
			
			
		}
		else
		{
		
			Debug.Log ( "DISTANCE TO GREAT TO SPAWN" );
			SpawnRandomEnemy();
		
		}
		
		//Return a random waypoint GameObject
		
	
	}
	*/
	
}
