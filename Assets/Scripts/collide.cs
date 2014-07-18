using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class collide : MonoBehaviour {
	private Stack <GameObject> targets;
	private GameObject hexTarget;
	private GameObject goToHere;

	private bool latch;

	void Start () {
		targets = new Stack<GameObject> ();
		hexTarget = null;
		latch = true;
	}

	void Update () {
		// if I've hit a hexagon, and the latch is open
		if (hexTarget != null && latch) {
			// set the destination to the last thing that wasn't a hexagon
			goToHere = (GameObject)targets.Pop();
			while(goToHere.gameObject.name == "hex"){
				goToHere = (GameObject)targets.Pop();
			}
			// close the latch
			latch = false;
		}

		// upon latch closing, replace projectile with actual hex, transfer data, and destroy projectile
		if (!latch) {
			transform.position = Vector3.Lerp(transform.position, goToHere.transform.position, Time.deltaTime * 10f);
			if(transform.position == goToHere.transform.position){
				// New hex
				GameObject newHex = (GameObject)Instantiate(Resources.Load ("hex"));
				// Make it blend in
				newHex.name = "hex";
				// Assume the position of the projectile
				newHex.transform.position = transform.position;
				// Color match
				newHex.transform.FindChild("hexSprite").GetComponent<SpriteRenderer>().color = gameObject.transform.FindChild("hexSprite").GetComponent<SpriteRenderer>().color;
				newHex.transform.GetComponent<testHex>().myColor = gameObject.transform.FindChild("hexSprite").GetComponent<SpriteRenderer>().material.color;
				// Copy Units and values
				newHex.GetComponent<testHex>().Nint.text = gameObject.transform.FindChild("Nint").GetComponent<TextMesh>().text;
				newHex.GetComponent<testHex>().Dint.text = gameObject.transform.FindChild("Dint").GetComponent<TextMesh>().text;
				newHex.GetComponent<testHex>().numerator.text = gameObject.transform.FindChild("numerator").GetComponent<TextMesh>().text;
				newHex.GetComponent<testHex>().denominator.text = gameObject.transform.FindChild("denominator").GetComponent<TextMesh>().text;
				// newHex.transform.GetComponent<testHex>().Initiate();

				// Destroy the evidence
				StoichUnits.setOrigin(newHex);
				StoichUnits.setGrid(true);

				StoichUnits.setShoot(true);
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider target){
		// If I haven't hit a hexagon in the past
		if (hexTarget == null) {
			// push whatever I collided with
			targets.Push (target.gameObject);

			//if I hit a hexagon
			if (target.gameObject.name == "hex") {
				// save the hexagon I hit
				hexTarget = target.gameObject;
				// slow me down
				rigidbody.velocity = Vector3.zero;
			}
		}
	}
}
