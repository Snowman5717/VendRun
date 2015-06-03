using UnityEngine;
using System.Collections;

public class Winning : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Vend")
		{
			gameOver.printOut = "Player 1 Won in " + timeText.time.ToString("F2") + "seconds!";

			Application.LoadLevel(2);
		}
	}
}
