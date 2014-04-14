using UnityEngine;
using System.Collections;

public class ammo : MonoBehaviour {

	public int colorIndex;
	
	void Start () {
		colorIndex = 0;
		pickColor ();
	}

	void Update () {
		// Cycle the color
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
			if(colorIndex == 3){
				colorIndex = 0;
			}else{
				colorIndex++;
			}
			pickColor();
		}
		// Cycle the color in the opposite direction
		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {
			if(colorIndex == 0){
				colorIndex = 3;
			}else{
				colorIndex--;
			}
			pickColor();
		}
	}
	// set the color according to the color index
	void pickColor(){
		switch(colorIndex){
		case 0:
			gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
			break;
		case 1:
			gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
			break;
		case 2:
			gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
			break;
		default:
			gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
			break;
		}
		// update the barrel color as well
		gameObject.transform.FindChild("barrel").GetComponent<MeshRenderer>().material.color = gameObject.GetComponent<MeshRenderer> ().material.color;
	}

}
