using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawnScriptLevel3 : MonoBehaviour
{
    public GameObject [] objects;
	private float randomnumber;
	private float customerdecider;
	private float time;
	private float timeregen = 1.75f;
	public int customersspawned = 0;
	private bool win;
	private int lane;
	private bool stoploading;
    // Start is called before the first frame update
	void Awake()
	{
		timeregen = 1.75f;
	}

    // Update is called once per frame
	void Update()
	{
		//als je hebt gewonnen voer de won functie ui
		if (win == true){
			Won();
		}
		//Als de level nog niet klaar is, spawn randomly een customer in de level
		if (win != true){
			time -= Time.deltaTime;
			if (time <= 0){
				randomnumber = Random.Range(0f,4f);
				if(randomnumber <= 1){
					lane = 3;
					spawn( new Vector3(-9.56f,2.79f,0f));
					customersspawned++;
				}

				else if(randomnumber >2 && randomnumber <=3) {
					lane = 2;
					spawn(new Vector3(-9.56f,0.8f,0f));
					customersspawned++;
				}

				else if(randomnumber >1 && randomnumber <=2) {
					lane = 1;
					spawn(new Vector3(-9.56f,-1.22f,0f));
					customersspawned++;
				}

				else if(randomnumber >3 && randomnumber <=4) {
					lane = 0;
					spawn(new Vector3(-9.56f,-3.2f,0f));
					customersspawned++;
				}

				if(timeregen >0){
					timeregen -= 0.05f;
				}
				if (timeregen <0){
					timeregen = 0; };
					time = timeregen + 0.75f + Random.Range(0f,0.5f);
				}
				if(stoploading == false){
				if (customersspawned >= 35){
					win = true;
					stoploading = true;
				}}
			}
		}
		void spawn(Vector3 spawnposition){
			if(GameObject.Find("Ricardo(Clone)") == null){
				customerdecider = Random.Range(0,4f);
				if(customerdecider <= 1.3f)
				{
					GameObject customerobject = (GameObject)Instantiate(objects[0], spawnposition, transform.rotation);
					CustomerController customerscript = customerobject.GetComponent<CustomerController>();
					customerscript.lane = lane;
				}
				else if(customerdecider >1.3f && customerdecider <=2.6f)
				{
					GameObject customerobject = (GameObject)Instantiate(objects[1], spawnposition, transform.rotation);
					CustomerController customerscript = customerobject.GetComponent<CustomerController>();
					customerscript.lane = lane;
				}
				else if(customerdecider >2.6f && customerdecider <=3.9f)
				{
					GameObject customerobject = (GameObject)Instantiate(objects[2], spawnposition, transform.rotation);
					CustomerController customerscript = customerobject.GetComponent<CustomerController>();
					customerscript.lane = lane;

				}
				else if(customerdecider >3.9f && customerdecider <=4){
					GameObject customerobject = (GameObject)Instantiate(objects[3], spawnposition, transform.rotation);
				}
			}

			
		}
		void Won(){
			if(GameObject.FindGameObjectsWithTag("Customer").Length == 0){
			Debug.Log("You won??");
			GameObject go = GameObject.Find("GameManagement");
			SceneLoader other = (SceneLoader) go.GetComponent(typeof(SceneLoader));
			other.WinLevel3();
			win = false;
		}}
}
