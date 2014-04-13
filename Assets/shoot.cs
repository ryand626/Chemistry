using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	public GameObject projectileTemplate;
	public float fireSpeed;

	private GameObject projectile;

	// Initially the projectile is blank
	void Start () {
		StoichUnits.setShoot (true);
		projectile = null;
		StoichUnits.RandomUnit(projectileTemplate.transform.FindChild("numerator").GetComponent<TextMesh>(),
		                       projectileTemplate.transform.FindChild("denominator").GetComponent<TextMesh>(),
		                       projectileTemplate.transform.FindChild("Nint").GetComponent<TextMesh>(),
		                       projectileTemplate.transform.FindChild("Dint").GetComponent<TextMesh>());
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && StoichUnits.canShoot) {
			// prevent more firing
			StoichUnits.setShoot(false);
			// clone the template
			projectile = (GameObject)Instantiate(projectileTemplate);
			// Set the color
			projectile.transform.FindChild("hexSprite").GetComponent<SpriteRenderer>().material.color = gameObject.GetComponent<MeshRenderer>().material.color;
			// Set the position and velocity (turn off gravity)
			projectile.transform.position = transform.position;
			projectile.rigidbody.velocity = (transform.FindChild("barrel").position - transform.position) * fireSpeed;
			projectile.rigidbody.useGravity = false;
			// Copy Data from template
			projectile.transform.FindChild("numerator").GetComponent<TextMesh>().text = projectileTemplate.transform.FindChild("numerator").GetComponent<TextMesh>().text;
			projectile.transform.FindChild("denominator").GetComponent<TextMesh>().text= projectileTemplate.transform.FindChild("denominator").GetComponent<TextMesh>().text;
			projectile.transform.FindChild("Nint").GetComponent<TextMesh>().text = projectileTemplate.transform.FindChild("Nint").GetComponent<TextMesh>().text;
			projectile.transform.FindChild("Dint").GetComponent<TextMesh>().text = projectileTemplate.transform.FindChild("Dint").GetComponent<TextMesh>().text;
			// Add collision detection
			projectile.AddComponent<collide>();
			// Randomize the next units
			StoichUnits.RandomUnit(projectileTemplate.transform.FindChild("numerator").GetComponent<TextMesh>(),
			                       projectileTemplate.transform.FindChild("denominator").GetComponent<TextMesh>(),
			                       projectileTemplate.transform.FindChild("Nint").GetComponent<TextMesh>(),
			                       projectileTemplate.transform.FindChild("Dint").GetComponent<TextMesh>());
		}
	}
}
