using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
	public float time;
	public float health = 0;
	void Start(){
		time = 0.5f;
	}
    // Update is called once per frame
	void Update()
	{	time -= Time.deltaTime;
		if(health < 0 && time <= 0){
			this.transform.parent.GetComponent<EnemyScript>().health -= 1;
			health = 0;
		time = 0.5f;
		}
	}
	void OnCollisionEnter2D(Collision2D collision){
	if(collision.gameObject.name == "Player"){
		collision.gameObject.GetComponent<PlayerHealthScript>().Health -= 1;
		Debug.Log("YES PLS KILL ME");
	}
	}
}
