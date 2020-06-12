using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "bullet") {	//checks if object you hit is a bullet
			bullet bulscript = col.gameObject.GetComponent<bullet>(); //gets bullet script from bullet to see variables
			bulscript.CreateSpark(col.gameObject);
			Destroy(col.gameObject);	//destroys bullet that hit it
		}
    }
}
