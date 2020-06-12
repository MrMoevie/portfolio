using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {
	
	public GameObject curser; //gameobject of the curser (that thing that follows the mouse)
	
	public GameObject bulletprefab;	//gameobject of bullet
	
	public float speed; //movement speed
	
	public GameObject gun; // gameobject of gun, only set when you hit a gun
	
	public GameObject camera; // just the camera

	public GameObject healthbar;	//is the healthbar you see on the top left of the screen
	public GameObject ammobar;	//is the ammo bar you see on the top left of the screen
	
	public float ammo = 0;	//ammount of ammo the player has
	public Vector3 lastmousepos;	//used to save the last mouse position, and is used for deciding if the player wants to use the controller of mouse
	
	public float amountofscreenshake = 1;
	public float shake = 0;
	private Vector3 old_camera;
	
	// Use this for initialization
	void Start () {
		old_camera = camera.transform.position;
		lastmousepos = Input.mousePosition;
	}
	
	float timer = 0;
	// Update is called once per frame
	void Update () {
		
		float sh = Input.GetAxis("secHorizontal"); // gets horizontal input from second joystick of the controller
		float sv = Input.GetAxis("secVertical"); // gets horizontal input from second joystick of the controller
		if(sh + sv == 0 || lastmousepos != Input.mousePosition){	//checks if the controller is used and if the mouse has moved
			if(timer > 0) {
				timer-=Time.deltaTime;
			}else {
				lastmousepos = Input.mousePosition;
				Vector3 cur = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets mouse position and is going to be used with the curser
				cur.z = 0;	//sets the z axis to 0 in order to not be confused and too prevent weird errors (honestly it just was in the stack overflow answer)
				curser.transform.position = cur; // sets curser to mouse position.
			}
		}else {
			timer = 1;
			Vector3 cur = new Vector3(sh * 4, 0 - sv * 4, 0) + transform.position; // moves curser position with controller second joystick.
			Vector3 oldcur = curser.transform.position;
			curser.transform.position = new Vector3((cur.x + oldcur.x + oldcur.x) / 3f, (cur.y + oldcur.y + oldcur.y) / 3f, 0);
			//curser.transform.position = curser.transform.position + new Vector3( (cur.x - oldcur.x) * 1f * Time.deltaTime, (cur.y - oldcur.y) * 1f * Time.deltaTime, 0);
		}
		
		if(Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetAxis ("shoot") != 0){ //checks if you are pressing the space bar
			if(gun!=null && ammo > 0) { //checks if you have gun
				Gun gunscript = gun.GetComponent<Gun>(); // gets gun script with variables from gun
				gunscript.fire = true; // sets gun to fire. but only fires when reload time is over
			}
		} // a bracket
		
		transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0); // moves the player! with build in controller support
		
		float camera_range = 0.2f;
		float camera_speed = 20;
		
		camera.transform.position = old_camera;
		
		if(camera.transform.position.x - transform.position.x < -camera_range) {camera.transform.Translate ( ( transform.position.x - camera.transform.position.x) / camera_speed , 0f, 0f);} //moves camera
		if(camera.transform.position.x - transform.position.x > camera_range) {camera.transform.Translate ( ( transform.position.x - camera.transform.position.x) / camera_speed , 0f, 0f);}	//moves camera some more
		if(camera.transform.position.y - transform.position.y > camera_range) {camera.transform.Translate ( 0f,  (transform.position.y - camera.transform.position.y) / camera_speed, 0f);}	// moves camera even more
		if(camera.transform.position.y - transform.position.y < -camera_range) {camera.transform.Translate ( 0f , ( transform.position.y - camera.transform.position.y) / camera_speed, 0f);} //its a jojo reference
		
		old_camera = camera.transform.position;
		if(shake > 0){
			camera.transform.position += new Vector3(Random.Range(-shake, shake), Random.Range(-shake, shake), 0f);
			Vector3 cp = camera.transform.position;
			camera.transform.position = new Vector3(cp.x, cp.y, -10f);
			shake -= Time.deltaTime * 4;
		}	
		if(gun !=null) {gun.transform.position = transform.position;} // puts gun in players position
		
		health h = GetComponent<health>();	//gets health component from player

		healthbar.transform.localScale = new Vector3(h.healthobj / 100f, 1f, 0f);	//changes the size of the healthbox
		ammobar.transform.localScale = new Vector3(ammo / 10f, 1f, 0f);				//changes the size of the ammobox
		
		if(ammo < 0) {	//fixes weid ammo bugs.. just te be sure
			ammo =0;
		}
	}
	
	void OnTriggerEnter2D(Collider2D col) //if you hit another object with a trigger. col is that gameobject you hit
    {
        if(col.gameObject.tag == "gun") {	//checks if object you hit is "gun"
			
			Gun gunscript = col.GetComponent<Gun>(); // gets script and is used to get the variables from gun
			if(gunscript.holder == null){	//checks if gun is not already in use
				if(gun != null){if(col.gameObject.name != gun.name){
					Gun gscript = gun.GetComponent<Gun>(); // gets script and is used to get the variables from gun
					gscript.holder = null;	//sets gun holder to nobody so that it can be picked up
				}}
				gun=col.gameObject;	//puts it as your main gun (yes, a inventory of 1)
				gunscript.holder = gameObject;	// says you own the gun (in order to not hit your self)
				gunscript.target = GameObject.Find("curser"); //sets target to curser so the bullets will go towards it
				
			}
		}
		if(col.gameObject.tag == "ammo") {	//checks if object you hit is an ammopack
		 	ammo amscript = col.gameObject.GetComponent<ammo>();	//gets variables from ammo box
			ammo += amscript.amount;	//adds ammo from ammobox to players ammo
			Destroy(col.gameObject);	//destroys ammobox
		}
		if(col.gameObject.tag == "health") {	//checks if object you hit is a healthpack
		 	heal heel = col.gameObject.GetComponent<heal>();	//gets variables from healthbox
			health live = GetComponent<health>();	//gets players health variables
			live.healthobj += heel.amount;		//adds health to players health
			Destroy(col.gameObject);	//destroys healthbox
		}

    }
	
	public void screenshake (float scsh_amount){
		shake += scsh_amount;
	}
	
}
