using UnityEngine;
using System.Collections;

public class MachineGun : MonoBehaviour 
{
	
	
	public GameObject muzzleLight; 
	private GameObject target;
	
	private ParticleEmitter muzzleFlash;
	
	

	
    public bool okToFlash = true;
	
	public float damageAmount;
	
	//A variable that will count how many bullets were shot
	private int counter = 0;
	//a Transform that is used to instantiate the bullet
	public Transform muzzleTransform;
	//a variable to store the Bullet game object loaded from the Resources folder
	private GameObject bullet;
	//A variable that serves as a handle to the newly instantiated bullet
	private GameObject instantiatedBullet;
	//This Quaternion defines the rotation of each instantiated bullet
	private Quaternion bulletRotation = new Quaternion(0.7f,0,0,0.7f);
	
	public float rateOfFire;
	
	public AudioClip sound;
	
	private PerFrameRayCast rayCast;
	

	
	void Awake()
	{
		
		rayCast = gameObject.GetComponent<PerFrameRayCast>();
		
		muzzleLight.SetActive( false );
		
	}
	
	void Start()
	{
	
	
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//while the "Fire1" button is being held down
		if( Input.GetButton( "Fire1" ) )
		{
			
			StartCoroutine( "MuzzleFlash", 0.1f );
			
			//Start the DelayedShot method as a coroutine
			StartCoroutine("DelayedShot", rateOfFire );
			
			
			
		}
	}
	
	//A method that returns a IEnumerator so it can be yield
	IEnumerator DelayedShot(float delay)
	{
		
		//wait for the time defined at the delay parameter
		yield return new WaitForSeconds(delay);
	
		// Find the object hit by the raycast
	    RaycastHit hitInfo = rayCast.GetHitInfo ();
		
	    
		// Spawn visual bullet
		//float coneRandomRotation = Quaternion.Euler (Random.Range (-coneAngle, coneAngle), Random.Range (-coneAngle, coneAngle), 0);
		
		
		//var go : GameObject = Spawner.Spawn (bulletPrefab, spawnPoint.position, spawnPoint.rotation * coneRandomRotation) as GameObject;
			//var bullet : SimpleBullet = go.GetComponent.<SimpleBullet> ();
		
		
		if( hitInfo.transform ) //if we hit something 
		{
			target = hitInfo.transform.gameObject;
			if( target.tag == "Enemy" )
			{
			
				 
				
				//hitInfo.transform.gameObject.SendMessage( "Damage" , damageAmount ) ;
				
				Debug.Log ( "Shooting : " + target.name );
				Messenger.Broadcast<float>( hitInfo.transform.gameObject,  "Damage" , damageAmount);
				
				
			
			}
			else if( target.tag == "Destructable" )
			{
				
				
				hitInfo.transform.gameObject.SendMessage( "Damage" , damageAmount ) ;
			
			
			}
			else if( target.tag == "Mine" )
			{
				
				
				hitInfo.transform.gameObject.SendMessage( "Detonate" , target ) ;
			
			
			}
			
			
		  
		
		
		
		}
		else
		{
			
			Debug.Log( "We hit nothing!!" );
		
		}
		
	    audio.PlayOneShot( sound );
			
	    counter++;
		    //Stop this coroutine
		
		
		StopCoroutine("DelayedShot");
		
		
		
		
	}
	
	void OnGUI()
	{
		//display how many bullets were shot
		GUI.Label(new Rect(10,30,100,30),"Shots fired: "+counter.ToString());
	}
	
	
	// Generate a Muzzle flash for each shot fired
	IEnumerator MuzzleFlash( float muzzleFlashDuration )
	{
		
		//point light is used as a light source for the muzzle flash
		muzzleLight.SetActive( true );
		muzzleLight.light.intensity = Random.Range(0.5F, 1.89F); //randomize light intensity
		muzzleLight.light.range = Random.Range(2.5F, 3.89F); //randomize light range
		
		yield return new WaitForSeconds( muzzleFlashDuration );
	
		muzzleLight.SetActive( false );
		
		StopCoroutine( "MuzzleFlash" );
		
		
	
	}
	
	
}

