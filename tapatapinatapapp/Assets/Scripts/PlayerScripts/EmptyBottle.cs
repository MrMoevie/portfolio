using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBottle : MonoBehaviour
{
	public float speed = 1;
	public int lane;
	void start() {
		
	}
    // Update is called once per frame
	void FixedUpdate()
	{
		// Constant de bottle naar links laten gaan
		transform.Translate(Vector3.right * Time.deltaTime * speed);
	}
	// Als de bottle de Bottle iets raakt
	void OnTriggerEnter2D(Collider2D col) {
		switch (col.gameObject.name){
			// is het de customercollider?
			case "CustomerCollider":
			// check of de lane waar de speler zit overeenkomt met de lane van de bottle
			if(GameObject.Find("Player").GetComponent<PlayerMovement>().position == lane) {
				// voer pickup uit
				PickUp();
			} else {
				// De bottle heeft gemist, leven eraf
				MissedBottle();
			}
			break;
			// check of de speler de bottle raakt
			case "Player":
			// voer pickup uit
			PickUp();
			break;
		}
	}
	void PickUp() {
		// vernietig gameobject en geef 25 punten
		Destroy(gameObject);
		HighscoreScript.instance.points += 25;
	}
	void MissedBottle() {
		// vernietig gameobject, haal een leven erfan en herlaad de level
		Destroy(gameObject);
		GameObject.Find("HealthManagement").GetComponent<HealthScript>().lives -= 1;
		GameObject go = GameObject.Find("GameManagement");
		SceneLoader other = (SceneLoader) go.GetComponent(typeof(SceneLoader));
		other.GameOver();
		Debug.Log("You lost");
	}
}
