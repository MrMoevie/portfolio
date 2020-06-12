using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ShootingScript : MonoBehaviour
{
	public GameObject projectile;
	public static bool fired = false;
	public static int ammo = 80;
	private int maxammo = 80;
	public float startreloadtime = 10;
	private float reloadtime;
	public GameObject PlayerMovement;
	public TextMeshProUGUI TextPro;

	void Start () {
		reloadtime = startreloadtime;
	}

	void FixedUpdate()
	{
		if(ammo > maxammo) {
			ammo = maxammo;
		}
		TextPro.text = ammo + "/" + maxammo;
		if (Input.GetButtonDown("Fire1")) {
			if (!fired && ammo > 0) {
				Fire();
				fired = true;
				PlayerMovement.GetComponent<PlayerMovement>().Knockback();
			}
		}
		if (fired) {
			reloadtime--;
		}
		if(reloadtime < 0) {
			fired = false;
			reloadtime = startreloadtime;
		}
	}
	void Fire() {
		Instantiate(projectile, transform.position, transform.rotation);
		FindObjectOfType<audiomanager>().Play("ShootingRocket");
		ammo--;
	}
}