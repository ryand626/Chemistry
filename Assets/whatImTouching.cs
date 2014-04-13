using UnityEngine;
using System.Collections;

public class whatImTouching : MonoBehaviour {
	public GameObject theButt;
	public bool check;

	void Awake(){
		check = true;
	}

	void OnTriggerStay(Collider whatWhat){
		if (check) {
			if (whatWhat.gameObject.name == "hex") {
				theButt = whatWhat.gameObject;
				//check = false;
				//this.enabled = false;
			}
		}
	}
}
