using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class inventoryImage : MonoBehaviour {
    
    public Sprite powerAid;
    private Sprite defaultImage;
    Image image;



	// Use this for initialization
	void Start () {

        image = GetComponent<Image>();

        defaultImage = image.sprite;

	}
	
	// Update is called once per frame
	void Update () {

        if(PlayerInput.item == 1)
        {
            image.sprite = powerAid;
        }
        else
        {
            image.sprite = defaultImage;
        }
	
	}
}
