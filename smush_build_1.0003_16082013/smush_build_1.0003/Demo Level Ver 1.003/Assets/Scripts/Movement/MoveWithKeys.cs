using UnityEngine;
using System.Collections;

public class MoveWithKeys : MonoBehaviour {

	
	public float speedUpDuration;
	public float speed;
    public float jumpSpeed = 8.0F;
    public float gravity = 35.0F;
    private Vector3 moveDirection = Vector3.zero;
	
	private int playerLives;
	
	public RaycastHit hit;
	
	private CharacterController controller; 
	
	
	void OnEnable()
	{
	
		Messenger.AddListener( "SpeedUp" , SpeedUp );
		
		
	}
	
	void OnDisable()
	{
		
		Messenger.RemoveListener( "SpeedUp" , SpeedUp );
		
		
	}
	
	
	// Use this for initialization
	void Start () 
	{
	  controller = GetComponent<CharacterController>();
	 
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	
	
		if (controller.isGrounded) 
		{
            
			
			
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            
			Debug.DrawRay(transform.position, moveDirection*3, Color.red);
			
			
			if (Physics.Raycast (transform.position,moveDirection,out hit, 2)) 
			{
				
				
				 
        		 //audio.PlayOneShot(punch);
				//print ("There is something in front of the object!" + hit.collider.gameObject.name);
				//Debug.Log("OUCH!! hit the " + hit.collider.gameObject.name);
		      
			
			
				
				
    		}
			
			if ( moveDirection != Vector3.zero ) 
            //transform.rotation = Quaternion.LookRotation( moveDirection );
			
			
			
			//moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            
			
 		  


			
			
			
			if (Input.GetButton("Jump"))
			{
                moveDirection.y = jumpSpeed;
			}
			
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	
	
	
	
	}
	
	void SpeedUp()
	{
		
		speed = speed * 2;
		StartCoroutine( "IncreaseSpeed" );
		
	}
	
	IEnumerator IncreaseSpeed()
	{
	
		
		int count = 0; 
		
		while( count <= speedUpDuration )
		{
		
			yield return new WaitForSeconds( 1.0f );
			count++;
			
		
			
		}
		
		speed = speed * 0.5f;
		
	 }
	
		
}
