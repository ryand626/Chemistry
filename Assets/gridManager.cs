using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gridManager : MonoBehaviour {

	private Color tempColor;

	private ArrayList numerators = new ArrayList ();
	private ArrayList denominators = new ArrayList ();
	private ArrayList Nints = new ArrayList ();
	private ArrayList Dints = new ArrayList ();
	private ArrayList visited = new ArrayList();
	private Stack <GameObject> myStack = new Stack<GameObject>();

	// Initialization
	void Start () {
		StoichUnits.setGrid (false);
		Transform[] allChildren = GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			// set the color of all hexagons in the grid to random colors
			if(child.name == "hex"){
				tempColor = pickColor();
				StoichUnits.RandomUnit(child.FindChild("numerator").GetComponent<TextMesh>(),
				                       child.FindChild("denominator").GetComponent<TextMesh>(),
				                       child.FindChild("Nint").GetComponent<TextMesh>(),
				                       child.FindChild("Dint").GetComponent<TextMesh>());

				child.gameObject.GetComponent<testHex>().myColor = tempColor;
				child.gameObject.transform.FindChild("hexSprite").GetComponent<SpriteRenderer>().material.color = tempColor;

			}
		}
	}

	void Update(){
		if (StoichUnits.gridUpdate) {
			blank();
			StartCoroutine(updateGrid(StoichUnits.origin, StoichUnits.goal));
		}
	}

	// pick a random color between cyan, green, red, and yellow
	Color pickColor(){
		Color returnColor;
		switch(Mathf.RoundToInt(Random.Range(0,5))){
		case 0:
			returnColor =  Color.cyan;
			break;
		case 1:
			returnColor = Color.green;
			break;
		case 2:
			returnColor = Color.red;
			break;
		default:
			returnColor = Color.yellow;
			break;
		}
		return returnColor;
	}

	void blank(){
		visited.Clear ();
		numerators.Clear ();
		denominators.Clear ();
		Nints.Clear ();
		Dints.Clear ();
	}

	IEnumerator updateGrid(GameObject origin, string goal){
		origin.transform.parent = gameObject.transform;
		yield return new WaitForSeconds (.5f);
		StoichUnits.setGrid (false);
		// Add to visited
		myStack.Push (origin);
		// Add the string's information

		while (myStack.Count != 0) {
			origin = myStack.Pop();
			if(!visited.Contains(origin)){
				visited.Add(origin);
				testHex hex = origin.GetComponent<testHex> ();
				numerators.Add (hex.numerator.text);
				denominators.Add (hex.denominator.text);
				Nints.Add (hex.Nint.text);
				Dints.Add (hex.Dint.text);
				print ("NUMERATOR: " + hex.Nint.text + " " + hex.numerator.text);
				print ("DENOMINATOR: " + hex.Dint.text + " " + hex.denominator.text);
				if(hex.above){
					if(!visited.Contains(hex.above) && hex.above.GetComponent<testHex>().myColor == hex.myColor){
						myStack.Push(hex.above);
					}
				}
				if(hex.below){
					if(!visited.Contains(hex.below) && hex.below.GetComponent<testHex>().myColor == hex.myColor){
						myStack.Push(hex.below);
					}
				}
				if(hex.topRight){
					if(!visited.Contains(hex.topRight) && hex.topRight.GetComponent<testHex>().myColor == hex.myColor){
						myStack.Push(hex.topRight);
					}
				}
				if(hex.topLeft){
					if(!visited.Contains(hex.topLeft) && hex.topLeft.GetComponent<testHex>().myColor == hex.myColor){
						myStack.Push(hex.topLeft);
					}
				}
				if(hex.bottomRight){
					if(!visited.Contains(hex.bottomRight) && hex.bottomRight.GetComponent<testHex>().myColor == hex.myColor){
						myStack.Push(hex.bottomRight);
					}
				}
				if(hex.bottomLeft){
					if(!visited.Contains(hex.bottomLeft) && hex.bottomLeft.GetComponent<testHex>().myColor == hex.myColor){
						myStack.Push(hex.bottomLeft);
					}
				}
			}
		}
		foreach (string numerator in numerators) {
			foreach(string denominator in denominators){
				if(numerator == denominator){
					numerators.Remove(numerator);
					denominators.Remove(denominator);
				}
			}
		}

		bool found = false;
		int checker = 0;
		foreach (string numerator in numerators) {
			if(numerator == goal){
				found = true;
			}
			checker ++;
		}
		if (found == true) {
			foreach (GameObject thing in visited) {
				Destroy(thing);
			}
		}


		yield return null;
	}
}
