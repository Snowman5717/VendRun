using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	public static bool dead = false, respawnCheck = false;
	public int vendColor;
	public GameObject blueAnim, redAnim;
	private Renderer rend;
	private float respawnTimer = 0.0f;
    public GameObject spawn;
	
	void Start()
	{
		rend = GetComponent<Renderer>();
		rend.enabled = true;
	}
	void Update () 
	{
		if(dead == true)
		{
			KillPlayer(0);
            PlayerInput.rigidBody.constraints = RigidbodyConstraints.FreezePositionY;
			respawnCheck = true;
		}
		if(respawnCheck == true)
		{
			respawnTimer += Time.deltaTime;
		}
		if(respawnTimer > 5)
		{
            PlayerInput.rigidBody.constraints = RigidbodyConstraints.None;
            PlayerInput.rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
            transform.position = spawn.transform.position;
            transform.rotation = spawn.transform.rotation;
			rend.enabled = true;
			respawnTimer = 0;
			respawnCheck = false;
		}
	}
	
	void KillPlayer(int color)	//0 for blue 1 for red
	{
		if(color == 0)
		{
			rend.enabled = false;
			Instantiate(blueAnim, transform.position, Quaternion.identity);
			dead = false;
			killFeed.printOut = "Player Has Died!"; 	
		}
		else
		{
			Destroy(gameObject);
			Instantiate(redAnim);
		}
	}
}
