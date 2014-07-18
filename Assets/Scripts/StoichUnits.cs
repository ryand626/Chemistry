using UnityEngine;
using System.Collections;

public static class StoichUnits {
	// Provide random units
	public static bool canShoot;

	// Unit Labels
	public static string[,] units = {{"mg","g"},{"kg","g"},{"mL","cm^3"},{"L","mL"}};
	// Unit conversion rates
	public static string[,] conversions = {{"1000",""},{"","1000"},{"",""},{"","1000"}};

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
		int randNum = Random.Range (0,units.GetLength (0));
		numerator.text = units[randNum,0];
		denominator.text = units [randNum, 1];

		Nint.text = conversions [randNum, 0];
		Dint.text = conversions [randNum, 1];
	}
}
