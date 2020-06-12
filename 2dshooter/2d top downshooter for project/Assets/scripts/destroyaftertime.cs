using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyaftertime : MonoBehaviour {

	public float time=10;	//how long object has to live (change in editor)
	public float randomrange = 0; //adds a random value to time
	public bool fadeoutovertime = false;
	public bool getbiggerovertime = false;
	public float howbig = 1.5f;
	private float tm;
	// Use this for initialization
	void Start () {
		tm = time;
		if(randomrange != 0){  //random.range has some weird behavour so this is needed
			time += Random.Range(0f - (randomrange / 2),0f +  randomrange / 2); //makes time have a random value between time - randomrange/2 en time + randomrange/2
		}
	}
	
	// Update is called once per frame
	void Update () {
		time-= Time.deltaTime;	//keeps track of its live time
		if(time<0){	//checks if its livespan is over
			Destroy(gameObject);	//destroys gameobject
		}
		if(fadeoutovertime){
			Color c = GetComponent<SpriteRenderer>().color;
			GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, time/tm);
		}
	}
	
	void FixedUpdate() {
		
		if(getbiggerovertime){
			transform.localScale *= howbig;
		}
	}
}
