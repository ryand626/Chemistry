using UnityEngine;
using System.Collections;

public class hoverZoom : MonoBehaviour {
	Vector3 scale;

	int hover;
	int expandTimer;

	bool grow;

	void Awake(){
		hover = 0;
		expandTimer = 0;
		grow = false;
		scale = this.transform.localScale;
	}

	void Update(){
		if (grow && expandTimer <= 5) {
			transform.localScale *= 1.05f;
			expandTimer++;
		}
	}

	void OnMouseEnter(){
		transform.position -= new Vector3 (0f, 0f, 1f);
	}

	void OnMouseOver(){
		if(hover >= 20){
			grow = true;
		}else{
			hover += 1;
		}
	}

	void OnMouseExit(){
		transform.position += new Vector3 (0f, 0f, 1f);
		transform.localScale = scale;
		expandTimer = 0;
		hover = 0;
		grow = false;
	}
}
