using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleScript : MonoBehaviour
{
	public float speed = 1;
    // Update is called once per frame
	void FixedUpdate()
	{
		// Constant de bottle naar links laten gaan
		transform.Translate(Vector3.left * Time.deltaTime * speed);
	}
	// Als de bottle de BottleCollider raakt die net buiten het level zit
	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.name == "PlayerCollider") {
			Destroy(gameObject);
			GameObject.Find("HealthManagement").GetComponent<HealthScript>().lives -= 1;
			GameObject go = GameObject.Find("GameManagement");
			SceneLoader other = (SceneLoader) go.GetComponent(typeof(SceneLoader));
			other.GameOver();
		}
	}
}
