using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {  //not even going to try and explain all of this shit.. good luck!
	
	public GameObject target;	//for target where the bullets are aimed at. example (player's target = curser)
	public GameObject holder;	//the gameobject that owns the gun. needed so that the holder doesn't shoot it self
	public GameObject bullet;	//what type of bullet is used. this is spawned every time the holder shoots
	
	public bool fire = false;	//used for firing. if holder wants to fire this turns to true
	public float screenshake = 0.2f;
	
	//bullet configuration
	public int timealive = 6;	//how long the bullet is alive
	public float spread = 0;	//how much the bullet('s) can spread
	public float damage = 1;	//how much damage the bullet can do
	public float speed = 1;		//speed of the bullet
	public int amountofbullets = 1;	//amount of bullets shot at once
	public float ammocost = 1;	//how much ammo it cost's per shot
	public int shootdistance = 4;
	public int flashchance = 5;
	public bool noammocost = false;
	public bool diesafterhit = true;
	public float bulletsizex = 1;
	public float bulletsizey = 1;
	
	//reloading	
	
	public float time = 0;		//forced time inbetween shots
	public AudioClip FireSound; //is the sound played when you fire
	public bool reload = false;	//is reloading a thing?
	public int maxshots;			//max amount of shot's before reloading is needed
	public int shotsfired;			//the amount of bullet's shot since last reload
	public float shootingtime= 10;	//how long it takes to reload
	public bool reloadbool = false;	//used to keep track if gun is reloading
	public float reloadtimer = 2.5f;	//keeps track of reload time
	public float reloadtime = 2.5f;		//used to reset the reloadtimer to reloadtime's value
	
	
	// Use this for initialization
	void Start () {
		//wow such empty
	}
	
	// Update is called once per frame
	void Update () {
		
		if(holder != null && holder.tag != "enemy" ){	//rotates gun towards target but enemy's turn on them self so for them its not needed
			
			transform.right = (target.transform.position - transform.position);	//rotates gun towords target
			transform.Rotate(0,0,-90);	//makes gun visible again by rotating it
			Vector3 rot = transform.rotation.eulerAngles;
			if(target.transform.position.x < transform.position.x && rot.z < 0) {rot.z = -rot.z;}
			transform.rotation = Quaternion.Euler(0,0, rot.z);
			
		}
		
		if(fire && time < 0) {	//checks if holder wants to fire and if there was enough time in between shots
			
			if (reload && shotsfired >= maxshots || reloadbool ){	//check if reload is needed
				reloadbool = true;	//used to remember if gun is reloading
				
			} else{
					
				int bulll = 0;	//keeps track of how many bullets are used in a single shot
				
				while(bulll !=amountofbullets){
					AudioSource.PlayClipAtPoint(FireSound,transform.position);
					if(holder != null && holder.name == "Player"){	//checks if the holder is player
						player playscript = holder.GetComponent<player>();	//gets variables from the player's script
						if(playscript.ammo < 0 && !noammocost) {break;}	//checks if player is out of bullets, yes > stop the while loop
					}
					
					shotsfired++;
					bulll++;
					
					GameObject bul = Instantiate(bullet); //makes bullet and puts it in a gameobject
					bullet bulletscript = bul.GetComponent<bullet>(); //get script variables
					bulletscript.spread = spread / 10;	//gives spread variable to bullet
					bulletscript.damage = damage;		//gives damage variable to bullet
					bulletscript.speed = speed;			//gives speed variable to bullet
					bulletscript.timealive = timealive;	//gives timealive variable to bullet
					bulletscript.holder = holder;		//gives holder variable to bullet
					bulletscript.target = target;		//gives target variable to bullet
					bulletscript.frames = shootdistance;
					bulletscript.chance = flashchance;
					bulletscript.diesafterhit = diesafterhit;
					bul.transform.localScale = new Vector3(bulletsizex, bulletsizey, 1);
					
					
					
					
				}
				
				if(holder!=null && holder.name == "Player"){	//checks if holder is player
						player playscript = holder.GetComponent<player>();	//gets variables from the player's script
						if (!noammocost)playscript.ammo -= ammocost;	//detracts the ammount of ammo the player has by the amount that it cost's
						playscript.screenshake(screenshake);
				}

				time = shootingtime;	//resets the time (as in time in between shots)
			}
		}
		
		if(holder != null && holder.name == "Player" && Input.GetKeyDown(KeyCode.R) && reload && !reloadbool){
			reloadbool = true;
		}
		
		if(reloadbool){	//if gun is reloading
			reloadtimer -= Time.deltaTime;	//keep track of how long it has been reloading
			if (reloadtimer < 0.0005f){	//if time is under 0.0005 than not reloading anymore
				shotsfired = 0;				//resets shotsfired that keeps track of when to reload
				reloadtimer = reloadtime;	//resets reloadtimer that keeps track of how long it takes to reload
				reloadbool = false;			//sets variable that keeps track if gun is reloading
			}
		}
		
		fire = false;	//sets gun to non-firing mode, so not to come in an endless firing loop
		time -= Time.deltaTime;
		
	}
	
	
}
