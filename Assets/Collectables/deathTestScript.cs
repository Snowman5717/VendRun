using UnityEngine;
using System.Collections;

public class deathTestScript : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		Destroy(gameObject);
		Death.dead = true;
		
	}
}
