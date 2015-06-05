using UnityEngine;
using System.Collections;

public class enemyFollowAI : MonoBehaviour {

    public GameObject player;
    public string botNumber;

    private GameObject[] beaconsList;
    private NavMeshAgent agent;
    private int currentPos;

	// Use this for initialization
	void Start () 
    {

        agent = GetComponent<NavMeshAgent>();        
        beaconsList = GameObject.FindGameObjectsWithTag(botNumber);

	}
	
	// Update is called once per frame
    void Update()
    {

        if(agent.remainingDistance < 2)
        {
            nextPatrolPosition();  
        }
    }

    void nextPatrolPosition()
    {
        if(beaconsList.Length == 0)
        {
            return;
        }

        agent.destination = beaconsList[currentPos].transform.position;

        currentPos = (currentPos + 1) % beaconsList.Length;
    }

}
