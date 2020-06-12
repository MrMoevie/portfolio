using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxScript : MonoBehaviour
{
	public int ammo = 6;
	private bool hit;

	 void OnTriggerEnter2D(Collider2D target)
 {
     if(target.tag == "Player"){
			ShootingScript.ammo += ammo;
			Destroy(gameObject);        
		}
	}
}
