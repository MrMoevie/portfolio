using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour {
	
	public GameObject player;	//finds the player
	public GameObject gun;	//what gun it shoots with
	
	public float range = 1; //how far the enemy stops from you
	public float speed = 1;	//enemy walking \ running speed
	public int meleedamage = 1;  //melee damage when oncollision enter happens in health with enemy;
	public float attackspeed = 1;	//how fast it does repeats melee damage

	private bool hasbeenspotted = false;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player"); //sets players gameobject right
	}
	
	// Update is called once per frame
	void Update () {

		if(Vector3.Distance(player.transform.position, transform.position) > 9 && !hasbeenspotted) {
			return;
		}
		hasbeenspotted = true;
		if(Vector3.Distance(player.transform.position, transform.position) > 14) {
			hasbeenspotted = false;
		}
		
		if(player == null) {return;}
		transform.right = (player.transform.position - transform.position); // rotates towards player
		
		if (player.transform.position.x > transform.position.x + range || player.transform.position.x < transform.position.x - range || player.transform.position.y > transform.position.y + range || player.transform.position.y < transform.position.y - range) {
			// ^ checks if player not to close
			transform.Translate(speed * Time.deltaTime, 0f, 0f); //moves enemy forward
		}
		
		if(gun!=null) { //checks if enemy has gun
			Gun gunscript = gun.GetComponent<Gun>(); // gets gun script with variables
			gunscript.fire = true;	//sets gun to fire
			gunscript.holder = gameObject;	//sets gun holder to himself so to not be shot by him self
			gunscript.target = GameObject.Find("Player"); // sets target (curser) to player
			gun.transform.position = transform.position; // puts gun in same position as enemy
		}
		
	}
}
