using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBoyScript : MonoBehaviour
{
	public int speed;
	public GameObject Ricardo;
	public Vector3 spawnlocation;
    // Start is called before the first frame update
	void Start()
	{

	}

    // Update is called once per frame
	void Update()
	{
		transform.Translate(Vector3.right * Time.deltaTime * speed);
	}
	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Soda") {
			Instantiate(Ricardo, spawnlocation, Quaternion.identity);
			Destroy(gameObject);
			Destroy(col.gameObject);
			HighscoreScript.instance.points += 10;
		}
		if(col.gameObject.name == "CustomerCollider") {
				Destroy(gameObject);
				Debug.Log("NOOO SPRITEBOIIII");
			}

	}
}
