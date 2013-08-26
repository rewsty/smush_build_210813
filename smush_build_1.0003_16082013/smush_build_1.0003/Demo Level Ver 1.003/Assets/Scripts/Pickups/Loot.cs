using UnityEngine;
using System.Collections;


public class Loot : MonoBehaviour 
{

	
	
	
	private string _name;
	private float _timeBetweenSpawn = 10.0f;
	private float _lootLifeSpan = 10.0f;
	private float _lootValue = 100.0f;
	private int _count;
	
	
	
	
	
	public Loot() //Constructor
	{
		
		
		_name = "Need Name";
		_lootLifeSpan = 0.0f;
		_lootValue = 0.0f;
		_timeBetweenSpawn = 0.0f;
		
		
	}
	
	public Loot( string name, float lifeSpan, float lootValue, float timeBetweenSpawn )
	{
	
		_name = name;
		_lootLifeSpan = lifeSpan;
		_lootValue = lootValue;
		_timeBetweenSpawn = timeBetweenSpawn;
		
		
	}
	
	
	public string name 
	{
	
		get{ return _name; }
		set{ _name = value; }
	
	}
	
	public float lootLifeSpan 
	{
	
		
		
		
		get{ return _lootLifeSpan; }
		set{ 
			
			Debug.Log ( "LifeSpan Value = " + value );
			_lootLifeSpan = value; 
		
		
		}
	
	}
	
	public float lootValue
	{
	    
		get{ return _lootValue; }
		set{ _lootValue = value; }
		
	}
	
	public float timeBetweenSpawn
	{
	    
		get{ return _timeBetweenSpawn; }
		set{ _timeBetweenSpawn = value; }
		
	}
	
	public int count
	{
	    
		get{ return _count; }
		set{ _count = value; }
		
	}
	
	
	private IEnumerator LifeSpan( )
	{
	
		int count = 0; 
		
		while( count <= _lootLifeSpan )
		{
		
			yield return new WaitForSeconds( 1.0f );
			count++;
			
			this.count = count;
			
		}
		
		gameObject.SetActive( false );
		
		
		
		
	}
	
	
	public void LifeCountDown()
	{
	
		StartCoroutine( "LifeSpan" );
		
	}
	
	
	public void killSelf( )
	{
	
		Destroy( this.gameObject );
		//gameObject.SetActive( false );
		
	}
	

	
}
