using UnityEngine;
using System.Collections;

public class hexGrid : MonoBehaviour {
	public GameObject above;
	public GameObject below;
	public GameObject topRight;
	public GameObject topLeft;
	public GameObject bottomRight;
	public GameObject bottomLeft;

	public Color myColor;

	public TextMesh numerator;
	public TextMesh denominator;
	private GameObject temp;

	// Use this for initialization
	void Start () {
		transform.FindChild ("hexSprite").GetComponent<SpriteRenderer> ().color = myColor;

//		if (transform.FindChild ("bottomRight").GetComponent<whatImTouching> ().theButt){
//			bottomRight = transform.FindChild ("bottomRight").GetComponent<whatImTouching> ().theButt;
//		}
//
//		if (transform.FindChild ("bottomLeft").GetComponent<whatImTouching> ().theButt){
//			bottomLeft = transform.FindChild ("bottomLeft").GetComponent<whatImTouching> ().theButt;
//		}
//
//		if (transform.FindChild ("topRight").GetComponent<whatImTouching> ().theButt){
//			topRight = transform.FindChild ("topRight").GetComponent<whatImTouching> ().theButt;
//		}
//
//		if (transform.FindChild ("topLeft").GetComponent<whatImTouching> ().theButt){
//			topLeft = transform.FindChild ("topLeft").GetComponent<whatImTouching> ().theButt;
//		}
//
//		if (transform.FindChild ("top").GetComponent<whatImTouching> ().theButt){
//			above = transform.FindChild ("top").GetComponent<whatImTouching> ().theButt;
//		}
//
//		if (transform.FindChild ("bottom").GetComponent<whatImTouching> ().theButt){
//			below = transform.FindChild ("bottom").GetComponent<whatImTouching> ().theButt;
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
