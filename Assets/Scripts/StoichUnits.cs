using UnityEngine;
using System.Collections;

public static class StoichUnits {
	// Provide random units
	public static bool canShoot;

	public static void setShoot(bool newCanShoot){
		canShoot = newCanShoot;
	}

	public static bool gridUpdate;
	public static void setGrid (bool newGrid){
		gridUpdate = newGrid;
	}

	public static GameObject origin;
	public static void setOrigin(GameObject newOrigin){
		origin = newOrigin;
	}

	public static string goal;
	public static void setGoal(string newGoal){
		goal = newGoal;
	}


	public static void RandomUnit(TextMesh numerator, TextMesh denominator, TextMesh Nint, TextMesh Dint){
		switch (Mathf.RoundToInt(Random.Range (0, 5))) {
		case 0:
			numerator.text = "blue";
			Nint.text = "1000";
			denominator.text = "kg";
			Dint.text = "";
			break;
		case 1:
			numerator.text = "mg";
			Nint.text = "1000";
			denominator.text = "g";
			Dint.text = "";
			break;
		case 2:
			numerator.text = "mL";
			Nint.text = "";
			denominator.text = "cm cubed";
			Dint.text = "";
			break;
		default:
			numerator.text = "mg";
			Nint.text = "3";
			denominator.text = "mol";
			Dint.text = "";
			break;
		}
	}
}
