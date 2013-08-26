using UnityEngine;
using System.Collections;

public class LootManager : MonoBehaviour {

	
	
	public GameObject[] floorTiles;
	public GameObject[] lootItems;
	
	
	public int lastSpawnPoint;
	
	public int LootLifeSpan;
	
	
	
	
		
	public int count = 0;
	
	
	public int delay = 25;
	
	// Use this for initialization
	void Start () 
	{
	
		
		floorTiles =  GameObject.FindGameObjectsWithTag( Tags.floor );
		lootItems =  GameObject.FindGameObjectsWithTag( Tags.loot );
		
		
		
		
		
		StartCoroutine( "SpawnLoot" , delay );
	
	}
	
	
	
	IEnumerator SpawnLoot( int delay )
	{
		
		int randomSpawnPoint;
		int randomLootItem;
		
		Vector3 temp;
		
		GameObject clone;
		
		while( true )
		{
		
			
			yield return new WaitForSeconds( delay );
			
			randomSpawnPoint = Random.Range( 0 , floorTiles.Length );
			randomLootItem = Random.Range( 0 , lootItems.Length );
			
		
			//Make sure that the loot does not spawn on the same spawn point twice in a row
			if( randomSpawnPoint == lastSpawnPoint )
			{
		
				randomSpawnPoint  = ( randomSpawnPoint + 1 ) % floorTiles.Length; //Randomly pick a spawnpoint
					
			}
			
			
			lastSpawnPoint = randomSpawnPoint;
			
			temp =  floorTiles[ randomSpawnPoint ].transform.position; 
		
			temp.y = temp.y + 0.15f;
		
		
		
			clone = ( GameObject )Instantiate( lootItems[ randomLootItem ] , temp , floorTiles[ randomSpawnPoint ].transform.rotation );
			
			if( clone  && !clone.active )
			{
			
				clone.SetActive( true );
			
			}
			
			Debug.Log ( "Spawning Loot at " + floorTiles[ randomSpawnPoint ].name );
		
		
	  }
	
	
	
	
	
	}
}