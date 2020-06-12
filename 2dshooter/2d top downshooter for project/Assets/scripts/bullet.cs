using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	public GameObject spark;	//for sparks
	
	public GameObject target; //what direction the bullet needs to go
	public float speed;	//bullets speed (change its value with gun not in here)
	public float timealive; // needed for despawning (change its value with gun not in here)
	public float spread = 0;	//needed for spread (so the bullets go as straigth as you are used to (handy for shotguns!)) (change its value with gun not in here)
	public float damage = 0;	// amount of damage it does when it hits a object (change its value with gun not in here)
	public GameObject holder; //who ever owns the gun from where this bullet came from
	public GameObject shoot;
	public int frames = 0;
	private float totaltimealive = 0;
	public int chance = 5;
	public bool diesafterhit = true;
	
	// Used for first frame of a gameobjects excitense
	void Start () {
		totaltimealive = timealive;
		transform.position = holder.transform.position; //sets spawn point of bullet
		transform.right = (target.transform.position - transform.position); // puts bullet in direction of target (target)
		transform.right += new Vector3(ran(), ran(), 0f); // changes direction with a bit of randomness
	}
	
	float ran () { //used to give a random value back, besides if it is 0 than it returns 1
		if(spread == 0) {return 1;}	//needed because random.range has weird behavouir
		return Random.Range(-spread, spread); // returns a random value
	}
	
	// Update is called once per frame
	void Update () {
		frames--;
		if(frames == 0 && Random.Range(0, chance) == 0){
			GameObject shut = Instantiate(shoot);
			shut.transform.position = transform.position + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0f);
		}
		
		if(timealive / totaltimealive < 0.4f){
			transform.localScale = new Vector3(scale(), scale(), 1f );
		}
		transform.Translate(speed * Time.deltaTime,0f,0f); //moves bullet forwards with the speed of speed
		
		if(timealive < 0){	//checks if bullet needs to despawn
			Destroy(gameObject);	//bullets despawning (RIP)
		}
		timealive -= Time.deltaTime;	//lowers the time it still has on this earth (or mars)
		
	}
	
	public void CreateSpark(GameObject atThisGameObject) {
		GameObject s = Instantiate(spark, atThisGameObject.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
		s.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-40f, 40f), Random.Range(-40f, 40f)));
		

	}
										   
	float scale () {
		if(timealive / totaltimealive < 0.15f){
			return timealive / (totaltimealive * 0.15f);
		}
		return 1;
	}
	
	
	
}
