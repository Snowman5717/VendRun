using UnityEngine;
using System.Collections;

public class RandoBox : MonoBehaviour {

	public GameObject poweraid;
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(-50 * Time.deltaTime, -60 * Time.deltaTime, 40 * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Vend")
		{
			int randomNumber = Random.Range(0,1);
			if(randomNumber == 0)
			{
				Debug.Log("PowerUp 1!");
				killFeed.printOut = "Player has picked up PowerAid!";
				Instantiate(poweraid);
				PlayerInput.item = 1;
			}
			else if(randomNumber == 1)
			{
				Debug.Log("PowerUp 2!");
			}
			else if(randomNumber == 2)
			{
				Debug.Log("PowerUp 3!");
			}
			else
			{
				Debug.Log("PowerUp 4!");
			}
			Destroy(gameObject);
		}
	}
}
