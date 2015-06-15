using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	
	public static Rigidbody rigidBody;
	public static int velocity = 20;
	public static int rotVelocity = 2;
	public static int item = 0; //0-nothing 1-poweraid 2-
	
	void Start () 
	{
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 force = transform.forward * velocity;
		if(Death.respawnCheck == false)
		{
			if(Input.GetKey(KeyCode.W))
			{
				rigidBody.AddForce (force);
			}
			if(Input.GetKey(KeyCode.S))
			{
				rigidBody.AddForce (-force);
			}
			if(Input.GetKey(KeyCode.A))
			{
				transform.Rotate(Vector3.up * -rotVelocity);
			}
			if(Input.GetKey(KeyCode.D))
			{
				transform.Rotate(Vector3.up * rotVelocity);
			}
			if(Input.GetKeyDown(KeyCode.LeftShift))
			{
				if(item == 1)
				{
					PowerAid.useItem = true;
				}
				else
				{
					Debug.Log ("Inventory: Empty!");	
				}
			}
		}
		
		
	}
}
