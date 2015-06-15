using UnityEngine;
using System.Collections;

public class wallTrapMovement : MonoBehaviour {

    public int wallSpeed = 0;
    public static bool activatedTrap = false;
    private Vector3 trapInitPos;
    
	void Start () {

        trapInitPos = gameObject.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

        if(activatedTrap == true)
        {
            transform.localPosition += new Vector3(Time.deltaTime * wallSpeed, 0, 0);
        }
        else if(transform.position != trapInitPos && activatedTrap == false)
        {
            transform.position = trapInitPos;
        }
	
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Vend")
		{
			Death.dead = true;
			killFeed.printOut = "Player has died to a wall-trap!"; 
		}
	}
}
