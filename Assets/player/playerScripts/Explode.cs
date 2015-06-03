using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	Rigidbody rigidbody;
	
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.AddExplosionForce(500, transform.position, 360, 3.0F);
		Destroy(gameObject, 5);
	}
	
	
}
