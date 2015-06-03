using UnityEngine;
using System.Collections;

public class enemyFollowAI : MonoBehaviour {

    public GameObject targetTwo;

    private Vector3 initPos;

    public GameObject player;

    private NavMeshAgent agent;

	// Use this for initialization
	void Start () 
    {

        agent = GetComponent<NavMeshAgent>();

        initPos = transform.position;
	
	}
	
	// Update is called once per frame
    void Update()
    {

        agent.SetDestination(targetTwo.transform.position);



    }

}
