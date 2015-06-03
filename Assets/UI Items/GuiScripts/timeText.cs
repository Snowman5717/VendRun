using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timeText : MonoBehaviour {

    public static float time;

    Text text;

	// Use this for initialization
	void Start () {
        time = 0;
        text = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        text.text = "Time " + time.ToString("F2");


	
	}
}
