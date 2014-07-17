using UnityEngine;
using System.Collections;

public class realign : MonoBehaviour {
	// Numerator text objects
	GameObject N;
	TextMesh numerator;
	TextMesh Nint;
	// Denominator text objects
	GameObject D;
	TextMesh denominator;
	TextMesh Dint;

	// Distance between label and number
	public float bufferDistance;

	// Grab the objects
	void Start () {
		bufferDistance = -.1f;

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
		// Numerator
		Vector3 nLabelPos;
		float nLabelWidth;

		Vector3 nNumPos;
		float nNumWidth;

		// Denominator
		Vector3 dLabelPos;
		float dLabelWidth;

		Vector3 dNumPos;
		float dNumWidth;

		float totalWidth;

		// Grab the data
		nLabelPos = numerator.renderer.bounds.center;
		nLabelWidth = numerator.renderer.bounds.size.x;

		nNumPos = Nint.renderer.bounds.center;
		nNumWidth = Nint.renderer.bounds.size.x;
		
		dLabelPos = denominator.renderer.bounds.center;
		dLabelWidth = denominator.renderer.bounds.size.x;
		
		dNumPos = Dint.renderer.bounds.center;
		dNumWidth = Dint.renderer.bounds.size.x;

		// DEBUG
		print ("Numerator: " + nLabelPos + " " + nLabelWidth + ", " + nNumPos + " " + nNumWidth);
		print ("Denominator: " + dLabelPos + " " + dLabelWidth + ", " + dNumPos + " " + dNumWidth);

		totalWidth = nNumWidth + nLabelWidth + bufferDistance * (numerator.text.Length + Nint.text.Length); 

		numerator.gameObject.transform.position = N.transform.position + new Vector3 (totalWidth / 2, 0f, 0f);
		Nint.gameObject.transform.position = N.transform.position - new Vector3 (totalWidth / 2, 0f, 0f);

		totalWidth = dNumWidth + dLabelWidth + bufferDistance * (denominator.text.Length + Dint.text.Length); 

		denominator.gameObject.transform.position = D.transform.position + new Vector3 (totalWidth / 2, 0f, 0f);
		Dint.gameObject.transform.position = D.transform.position - new Vector3 (totalWidth / 2, 0f, 0f);
	}
}
