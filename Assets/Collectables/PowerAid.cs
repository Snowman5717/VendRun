using UnityEngine;
using System.Collections;

public class PowerAid : MonoBehaviour 
{
	private float timeCooldown;
	private bool active;
	private Renderer rend;
	public static bool useItem = false;
	
	void Start()
	{
		rend = GetComponent<Renderer>();
		rend.enabled = false;
	}
	
	void OnTriggerEnter(Collider col)
	{
		PlayerInput.item = 1;
		if(!active)
		{
			killFeed.printOut = "Player has picked up PowerAid!";
			rend.enabled = false;
		}
	}
	
	void Update()
	{
		if(active)
		{
			timeCooldown += Time.deltaTime;
			if(timeCooldown > 8)
			{
				PlayerInput.velocity -= 15;
				PlayerInput.rotVelocity -= 1;
				timeCooldown = 0;
				active = false;
				Destroy(gameObject);
				Debug.Log("PowerAid Over!");
			}
		}
		if(useItem)
			UseItem();
	}
	
	void UseItem()
	{
		if(!active)
		{
			PlayerInput.item = 0;
			active = true;
			Debug.Log("PowerAid Used!");
			PlayerInput.velocity += 15;
			PlayerInput.rotVelocity += 1;
			useItem = false;
		}
	}
}
