using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {
	
	public float healthobj = 0;	//variable for health, name could not be health because the script is called that
	public GameObject blood;	//needed for spawning blood effects
	public float spread = 0.4f;	//spread of blood from objects position'
	public float enemyscreenshake = 2f;
	
	float attacktimer = 0;		//used to make that enemy can only do a melee attack every so often instead of every frame
	
	public bool dropammo = false;	//if gameObject drops ammo if killed
	public bool drophealth = false;	//if gameObject drops health if killed
	public GameObject ammobox;	//ammo box that is used when killed if dropammo is true
	public GameObject healthdrop;	//health box that is used when killed if drophealth is true
	
	
	float ran () { //used to give a random value back, besides if it is 0 than it returns 1
		if(spread == 0) {return 1;}	//needed because random.range has weird behavouir
		return Random.Range(-spread, spread); // returns a random value
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(healthobj <= 0) { // checks if dead

			if ( dropammo == true){	//checks if gameObject is set to drop ammo when dead
				GameObject ammo = Instantiate(ammobox);	//creates ammobox
				ammo.transform.position = transform.position;	//sets ammobox on the sameplace as gameObject
				ammo.transform.position += new Vector3(ran(), ran(), 0f); // changes position with a bit of randomness
			}

			if ( drophealth == true){
				GameObject healbox = Instantiate(healthdrop);
				healbox.transform.position = transform.position;
				healbox.transform.position += new Vector3(ran(), ran(), 0f); // changes position with a bit of randomness
			}
			
			if(gameObject.tag == "Enemy"){	//checks if gameobject is a enemy
				enemy1 en = GetComponent<enemy1>();	//gets enemy script with variables
				Gun gg = en.gun.GetComponent<Gun>();	//gets gun script that enemy has with variables
				gg.holder = null;	//sets gun holder to nobody so that gun can be picked up again
			}
			spawnblood();
			spawnblood();
			spawnblood();
			spawnblood();
			spawnblood();
			spawnblood();
			spawnblood();
			spawnblood();
			spawnblood();
			spawnblood();
			spawnblood();
			spawnblood();
			GameObject.Find("Controller").GetComponent<Controller>().score += 20;
			
			//if(gameObject.name== "Player"){
				player plscript = GameObject.Find("Player").GetComponent<player>();
				plscript.screenshake(enemyscreenshake);
			//}
			
			Destroy(this.gameObject);	//yeah dead (destroys gameobject) RIP
		}
		attacktimer += Time.deltaTime;	//used to keep track of time, so that melee attacks can't be done every frame
	}
	
	void OnTriggerEnter2D(Collider2D col) //when object hits an other object that has a trigger. col is that object.
    {
        if(col.gameObject.tag == "bullet") {	//checks if gameobject it hit was a bullet
		 	bullet bulscript = col.gameObject.GetComponent<bullet>(); //gets bullet script from bullet to see variables
			if(bulscript.holder.tag != gameObject.tag) {	//check if object didnt shoot these bullets self
				healthobj -= bulscript.damage;	//lowers health by the amount of damage set by gun on bullet
				if(blood != null && Random.Range(0, 5) == 1) {
					spawnblood();
				}
				bulscript.CreateSpark(col.gameObject);
				if(bulscript.diesafterhit) Destroy(col.gameObject);
				
				if(gameObject.name== "Player"){
					player plscript = GetComponent<player>();
					plscript.screenshake(plscript.amountofscreenshake);
				}
			}
		}

    }
	void OnCollisionStay2D(Collision2D col) //if it collided with something, col is the object it collided with
    {
		enemy1 enscript = col.gameObject.GetComponent<enemy1>();	//gets script from enemy to get variables from set script
        if(col.gameObject.tag == "enemy" && gameObject.tag != "enemy") {	//checks if object is enemy (yes enemys can hurt each other)
			if (attacktimer > enscript.attackspeed){
			healthobj -= enscript.meleedamage;	//lowers health by the amount of damage set by enemy's melee damage
			print("enemy melee attack");
			attacktimer = 0;	//resets attacktimer, witch is used to make melee attacks have a timeout
			}
		}
    }
	
	void spawnblood () {
		if(blood == null) {return;}
		GameObject blod = Instantiate(blood);
		//blod.transform.position = transform.position + new Vector3 (Random.Range(-spread - bulscript.speed/30f, spread + bulscript.speed/30f), Random.Range(-spread - bulscript.speed/30f, spread + bulscript.speed/30f), 0f); // punt blood in a position close too the object
		blod.transform.position = transform.position;
		float size = Random.Range(.4f, 3.5f);
		blod.transform.localScale = new Vector3(size, size, 1);
		blod.transform.Rotate(0, 0, Random.Range(0, 360));
		blod.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-400f, 400f), Random.Range(-400f, 400f)));
		return;
	}
	
}
