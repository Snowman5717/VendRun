using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class killFeed : MonoBehaviour {

    Text text;
    public static string printOut;

	// Use this for initialization
	void Start () {

        text = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

        text.text = printOut;
	
	}
}
