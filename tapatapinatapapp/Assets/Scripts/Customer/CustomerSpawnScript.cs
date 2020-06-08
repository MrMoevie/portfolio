using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawnScript : MonoBehaviour
{
	public GameObject [] objects;
	private float randomnumber;
	private float customerdecider;
	private float time;
	private float timeregen = 2.75f;
	private int lane;
		// Start is called before the first frame update
	void Awake()
	{
		timeregen = 2.75f;
	}

		// Update is called once per frame
	void Update()
	{  time -= Time.deltaTime;
		if (time <= 0){
			randomnumber = Random.Range(0f,4f);
			if(randomnumber <= 1){
				lane = 3;
				spawn( new Vector3(-9.56f,2.79f,0f));
			}

			else if(randomnumber >2 && randomnumber <=3) {
				lane = 2;
				spawn(new Vector3(-9.56f,0.8f,0f));
			}

			else if(randomnumber >1 && randomnumber <=2) {
				lane = 1;
				spawn(new Vector3(-9.56f,-1.22f,0f));
			}
			
			else if(randomnumber >3 && randomnumber <=4) {
				lane = 0;
				spawn(new Vector3(-9.56f,-3.2f,0f));
			}

			if(timeregen >0){
				timeregen -= 0.05f;
			}
			if (timeregen <0){
				timeregen = 0; };
				time = timeregen + 0.75f + Random.Range(0f,0.5f);
			}
		}

		void spawn(Vector3 spawnposition){
			//if(ricardo != true){
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
		//}
		}
	}
