using UnityEngine;
using System.Collections;

public class realign : MonoBehaviour {
	// OBJECTS

	// Numerator text objects
	GameObject N;
	TextMesh numerator;
	TextMesh Nint;
	// Denominator text objects
	GameObject D;
	TextMesh denominator;
	TextMesh Dint;

	// POSITIONS AND SIZES
	Vector3 nLabelPos;

	// Numerator
	float nLabelWidth;
	
	Vector3 nNumPos;
	float nNumWidth;
	
	// Denominator
	Vector3 dLabelPos;
	float dLabelWidth;
	
	Vector3 dNumPos;
	float dNumWidth;
	
	// Width of text and number
	float totalWidth;
	
	// Distance between label and number
	public float bufferDistance;

	// Grab the objects
	void Start () {
		bufferDistance = .01f;

		numerator = transform.FindChild ("numerator").GetComponent<TextMesh>();
		denominator = transform.FindChild ("denominator").GetComponent<TextMesh>();
		Nint = transform.FindChild ("Nint").GetComponent<TextMesh>();
		Dint = transform.FindChild ("Dint").GetComponent<TextMesh>();
		N = transform.FindChild ("N").gameObject;
		D = transform.FindChild ("D").gameObject;
	}

	void Update(){
		align ();
	}

	public void align(){
		// Grab all the data
		nLabelPos = numerator.renderer.bounds.center;
		nLabelWidth = numerator.renderer.bounds.size.x;

		nNumPos = Nint.renderer.bounds.center;
		nNumWidth = Nint.renderer.bounds.size.x;
		
		dLabelPos = denominator.renderer.bounds.center;
		dLabelWidth = denominator.renderer.bounds.size.x;
		
		dNumPos = Dint.renderer.bounds.center;
		dNumWidth = Dint.renderer.bounds.size.x;

		// DEBUG
		//print ("Numerator: " + nLabelPos + " " + nLabelWidth + ", " + nNumPos + " " + nNumWidth);
		//print ("Denominator: " + dLabelPos + " " + dLabelWidth + ", " + dNumPos + " " + dNumWidth);

		// Calculate the total width of the numerator text and number, plus the buffer space in between
		totalWidth = nNumWidth + nLabelWidth + bufferDistance * (numerator.text.Length + Nint.text.Length); 

		// Center the text by going half the total width from the center and back half of the width of the text
		// If the number field or text field is blank, just center the existing field
		if (numerator.text != "") {
				if (Nint.text != "") {
						numerator.gameObject.transform.position = N.transform.position + new Vector3 (totalWidth / 2 - nLabelWidth / 2 - numerator.text.Length * bufferDistance / 2, 0f, 0f);
						Nint.gameObject.transform.position = N.transform.position + new Vector3 (nNumWidth / 2 + Nint.text.Length * bufferDistance / 2 - totalWidth / 2, 0f, 0f);
				} else {
					numerator.gameObject.transform.position = N.transform.position;
				}
		} else {
			Nint.gameObject.transform.position = N.transform.position;
		}

		// Calculate teh total width of the denominator text and number, plus the buffer space in between
		totalWidth = dNumWidth + dLabelWidth + bufferDistance * (denominator.text.Length + Dint.text.Length); 

		// Center the text by going half the total width from the center and back half of the width of the text
		// If the number field or text field is blank, just center the existing field
		if (denominator.text != "") {
			if (Dint.text != "") {
				denominator.gameObject.transform.position = D.transform.position + new Vector3 (totalWidth / 2 - dLabelWidth / 2 - denominator.text.Length * bufferDistance / 2, 0f, 0f);
				Dint.gameObject.transform.position = D.transform.position + new Vector3 (dNumWidth / 2 + Dint.text.Length * bufferDistance / 2 - totalWidth / 2, 0f, 0f);
			} else {
				denominator.gameObject.transform.position = D.transform.position + new Vector3 (totalWidth / 2 - dLabelWidth / 2 - denominator.text.Length * bufferDistance / 2, 0f, 0f);
			}
		} else {
			Dint.gameObject.transform.position = D.transform.position + new Vector3 (dNumWidth / 2 + Dint.text.Length * bufferDistance / 2 - totalWidth / 2, 0f, 0f);
		}	
	}
}
