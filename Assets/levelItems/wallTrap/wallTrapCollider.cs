using UnityEngine;
using System.Collections;

public class wallTrapCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Vend")
        {
            Debug.Log("PLAYER IS BEING ATTACKED BY A WALL");
            wallTrapMovement.activatedTrap = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Vend")
        {
            Debug.Log("THE WALL IS CALM");

            wallTrapMovement.activatedTrap = false;
        }
    }
}
