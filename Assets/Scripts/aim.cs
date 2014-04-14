using UnityEngine;
using System.Collections;

public class aim : MonoBehaviour {
	// TODO: RESTRICT MOVEMENT
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			transform.Rotate(0f,0f,1f);
		}
		
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			transform.Rotate(0f,0f,-1f);
		}
	}
}
