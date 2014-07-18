using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gridManager : MonoBehaviour {

	// Goal Text
	TextMesh[] GoalText = new TextMesh[4];
	public TextMesh RedGoal;
	public TextMesh GreenGoal;
	public TextMesh YellowGoal;
	public TextMesh BlueGoal;
	// GOAL INFO
	string[] Goalgoal = new string[4];
	private string rGoal;
	private string gGoal;
	private string yGoal;
	private string bGoal;


	private Color tempColor;

	private ArrayList numerators = new ArrayList ();
	private ArrayList denominators = new ArrayList ();
	private ArrayList Nints = new ArrayList ();
	private ArrayList Dints = new ArrayList ();
	private ArrayList visited = new ArrayList();
	private Stack <GameObject> myStack = new Stack<GameObject>();

	ArrayList denominatorsToDestroy = new ArrayList ();
	ArrayList numeratorsToDestroy = new ArrayList ();
	
	// Initialization
	void Start () {
		StoichUnits.setGrid (false);

		GoalText[0] = RedGoal;
		GoalText[1] = GreenGoal;
		GoalText[2] = YellowGoal;
		GoalText[3] = BlueGoal;

		Goalgoal[0] = rGoal;
		Goalgoal[1] = gGoal;
		Goalgoal[2] = yGoal;
		Goalgoal[3] = bGoal;

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

		// Setup Goals
		ChooseGoal (RedGoal, rGoal, 0);
		ChooseGoal (GreenGoal, gGoal, 1);
		ChooseGoal (BlueGoal, bGoal, 2);
		ChooseGoal (YellowGoal, yGoal, 3);
	}

	// Update the grid if 
	void Update(){
		if (StoichUnits.gridUpdate) {
			blank();
			StartCoroutine(updateGrid(StoichUnits.origin, StoichUnits.goal));
		}
	}

	// TODO: have something randomy assign a new unit goal to the Units that exist
	void ChooseGoal(TextMesh goalText, string oldGoal, int index){
		oldGoal = StoichUnits.units[Random.Range(0, StoichUnits.units.GetLength(0)-1),0];
		goalText.text = oldGoal;
		StoichUnits.setGoal(index, oldGoal);
	}
	
	// Blank the lists used for the DFS
	void blank(){
		visited.Clear ();
		numerators.Clear ();
		denominators.Clear ();
		Nints.Clear ();
		Dints.Clear ();
		myStack.Clear ();
	}


	IEnumerator updateGrid(GameObject origin, string[] goal){
		if (!origin) {
			yield return null;
		}
		// Make sure the goal is for the correctly colered hex
		int goalIndex = 0;
		Color color = origin.gameObject.transform.FindChild("hexSprite").GetComponent<SpriteRenderer>().material.color;

		if(color == Color.red){
			goalIndex = 0;
		}else if (color == Color.green) {
			goalIndex = 1;
		}else if (color == Color.blue) {
			goalIndex = 2;
		}else if (color == Color.yellow) {
			goalIndex = 3;
		}

		origin.transform.parent = gameObject.transform;
		yield return new WaitForSeconds (.5f);
		StoichUnits.setGrid (false);
		// Add to visited
		myStack.Push (origin);
		// Add the string's information

		// DFS through point of contact making a list of same colored tiles
		while (myStack.Count != 0 && origin != null) {
			origin = myStack.Pop();
			if(!visited.Contains(origin)){
				visited.Add(origin);
				testHex hex = origin.GetComponent<testHex> ();
				numerators.Add (hex.numerator.text);
				denominators.Add (hex.denominator.text);
				Nints.Add (hex.Nint.text);
				Dints.Add (hex.Dint.text);
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


		// Cancel units
		foreach (string numerator in numerators) {
			foreach(string denominator in denominators){
				if(numerator == denominator){
					numeratorsToDestroy.Add(numerator);
					denominatorsToDestroy.Add(denominator);
				}
			}
		}

		foreach (string deletor in denominatorsToDestroy) {
			denominators.Remove(deletor);
		}

		foreach (string deletor in numeratorsToDestroy) {
			numerators.Remove(deletor);
		}

		// Check to see if the chain was converted to the correct unit
		bool found = false;
		int checker = 0;

		print("Searching for " + goal[goalIndex]);

		denominatorsToDestroy.Clear ();
		numeratorsToDestroy.Clear ();

		foreach (string numerator in numerators) {
			print("Numerator " + numerator);
			if(numerator == goal[goalIndex]){
				print("NUMERATOR: " + numerator);
				found = true;
			}
			checker ++;
		}

		// TODO: only set found to true if checker is 1

		// Destroy the chain when you converted the chain correctly
		if (found == true) {
			foreach (GameObject thing in visited) {
				Destroy(thing);
			}
			//ChooseGoal(GoalText[goalIndex],Goalgoal[goalIndex],goalIndex);
		}

		blank ();
		yield return null;
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
}
