using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	
	public static Rigidbody rigidBody;
	public static int velocity = 20;
	public static int rotVelocity = 2;
	public static int item = 0; //0-nothing 1-poweraid 2-
    public bool controlsEnabled = false;
 	
	void Start () 
	{
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (controlsEnabled)
        {
            Vector3 force = transform.forward * velocity;
            if (Death.respawnCheck == false)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    rigidBody.AddForce(force);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rigidBody.AddForce(-force);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(Vector3.up * -rotVelocity);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(Vector3.up * rotVelocity);
                }
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    if (item == 1)
                    {
                        PowerAid.useItem = true;
                    }
                    else
                    {
                        Debug.Log("Inventory: Empty!");
                    }


                }
            }
        }
		
	}

    
    void FixedUpdate()
    {
        //If the player presses escape, unlock the camera.
        if (Input.GetKey(KeyCode.Escape) && Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        //If the player clicks on the window, lock the camera. (Using buttonUp so that on screen buttons can be pressed.
        if (Input.GetMouseButtonUp(0) && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
