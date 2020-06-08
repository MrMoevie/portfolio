using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour {
	public float speed = 1;
	public int backwardsspeed = 3;
	public float randomchance = 1;
	public float randomstopeventchance = 60;
	private float timegoingbackwards = 0;
	private bool weirdtime = false;
	private float goevenfaster = 2f;
	private bool Donedrinking;
	private bool stopmoving = false;
	public Animator animator; // De Animator
	private Vector3 Offset;
	public GameObject emptybottle;  // De bottle om te gebruiken in de level
	private bool donenumbergeneration = false;
	public int lane;
	    // Start is called before the first frame update
	void Start()
	{
		Offset = new Vector3(0,0,0);
	}

    // Update is called once per frame
	void Update() {
		//Is ricardo in de scene
		if (GameObject.Find("Ricardo(Clone)") != null) {
			//Als ricardo er is, doe een random nummer generation, als het lukt zet de customer still
			if (!donenumbergeneration) {
				donenumbergeneration = true;
				if(GenerateRandomNumber() <= randomstopeventchance) {
					stopmoving = true;
				}
			}
		}
		else {
			stopmoving = false;
			donenumbergeneration = false;
		}

		if(!stopmoving) {
			if(weirdtime == true) {
				WeirdTime();
			}
			else if(timegoingbackwards > 0){
				GoBackwards();
			}
			else if (Donedrinking == true){
				DoneDrinking();
			}
			else {
				Movement();
			}
		}
		
	} 
	void OnTriggerEnter2D(Collider2D col) {
		if (timegoingbackwards <= 0) {
			if(col.gameObject.tag == "Soda" && weirdtime == false && !stopmoving) {
				if (GenerateRandomNumber()<= randomchance){
					//activates event
					weirdtime = true;
					Destroy(col.gameObject);
				}
				else {
					//Destroy de cola fles
					HighscoreScript.instance.points += 10;
					Destroy(col.gameObject);
					timegoingbackwards = 2;
				}
			}
			if(col.gameObject.name == "CustomerCollider" && weirdtime == false) {
				Destroy(gameObject);
				GameObject.Find("HealthManagement").GetComponent<HealthScript>().lives -= 1;
				GameObject go = GameObject.Find("GameManagement");
				SceneLoader other = (SceneLoader) go.GetComponent(typeof(SceneLoader));
				if(GameObject.Find("HealthManagement").GetComponent<HealthScript>().lives <= 0){
				other.GameOver();
			}}
		}
	}
	void OnBecameInvisible(){
		HighscoreScript.instance.points += 100;
		Destroy(gameObject);
	}

	void Movement(){
		animator.SetBool("IsDrinking", false);
		transform.Translate(Vector3.right * Time.deltaTime * speed);
	}
	void GoBackwards() {
		animator.SetBool("IsDrinking", true);
		transform.Translate(Vector3.left * Time.deltaTime * backwardsspeed);
		timegoingbackwards -= Time.deltaTime;
		Donedrinking = true;
	}
	void WeirdTime() {
		goevenfaster = goevenfaster + goevenfaster * Time.deltaTime;//makes the speed increase over time
		transform.Rotate(0, 0, goevenfaster);
		transform.Translate(Vector3.right * Time.deltaTime * goevenfaster);
	}
	void DoneDrinking(){
		GameObject emptybottleobject = (GameObject)Instantiate(emptybottle, transform.position + Offset, Quaternion.identity);
		EmptyBottle emptybottlescript = emptybottleobject.GetComponent<EmptyBottle>();
		emptybottlescript.lane = lane;
		HighscoreScript.instance.points += 10;
		Donedrinking = false;
	}
	public float GenerateRandomNumber() {
		return Random.Range(0f,100f);
	}	
}