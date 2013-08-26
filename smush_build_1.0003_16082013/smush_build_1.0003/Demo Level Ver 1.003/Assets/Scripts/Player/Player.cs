using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	
	
		void OnEnable()
	{
	
		//Add Listeners here
		Messenger.AddListener( "PlayerDead" , PlayerDead );
	
		
	}
	
	void OnDisable()
	{
		
	
		//Remove  Listeners
		Messenger.RemoveListener( "PlayerDead" , PlayerDead );
	}
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void PlayerDead()
	{
		
		Debug.Log ( "Player Dead" );
		
		
		//Death animation 
		//Respawn
		
	}
	
	
	
}
