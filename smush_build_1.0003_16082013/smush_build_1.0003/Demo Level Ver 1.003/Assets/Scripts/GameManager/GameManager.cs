using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	
	
	
	public static int score;
	public int playerLives;
	
	
	void OnEnable()
	{
	
		//Add Listeners here
		Messenger.AddListener( "AddPlayer" , AddPlayer );
		Messenger.AddListener( "KillPlayer" , KillPlayer );
		
		Messenger.AddListener<int>( "ManageScore" , ManageScore );
		Messenger.AddListener( "Test" , Test );
			
		
	}
	
	void OnDisable()
	{
		
	
		//Remove  Listeners
		Messenger.RemoveListener( "AddPlayer" , AddPlayer );
		Messenger.RemoveListener( "KillPlayer", KillPlayer );
		
		Messenger.AddListener<int>( "ManageScore" , ManageScore );
		Messenger.RemoveListener( "Test" , Test );
	}
	
	
	// Use this for initialization
	void Start () 
	{
	
		
		
		
		
		
	}
	

	
	void OnGUI()

    {

   		GUI.Label( new Rect( 40 ,10, 100, 50), "Score "  + score );
		
		GUI.Label( new Rect( 180 ,10, 100, 50), "Lives "  + playerLives );

    }
	
	
	public void ManageScore( int amount )
	{
	
		
		Debug.Log ( "Manage Score" );
		
		score = score + amount;
		
		
	}
	
	public void Test()
	{
	
		Debug.Log ( "Messenger Is OK" );
		
	}
	
	public void AddPlayer()
	{
	
		
		playerLives = playerLives + 1;
		
		
	}
	
	
	public void KillPlayer()
	{
	
		
		playerLives = playerLives - 1;
		
		Messenger.Broadcast( "PlayerDead" );
		
		if( playerLives == 0 )
		{
		
			Debug.Log ( "GameOver" );
			
		}
		
		
		
		
	}
	
	
	
	
}
