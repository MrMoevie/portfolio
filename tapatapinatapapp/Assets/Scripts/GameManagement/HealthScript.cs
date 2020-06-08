using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
	public int lives;
	public int maxlives = 3;
	
    // Start is called before the first frame update
    void Start()
    {
    	lives = maxlives;
    }
    void LateUpdate(){
    	if(lives == 0){
    		GameObject.Find("GameManagement").GetComponent<SceneLoader>().DEAD();
    		lives = maxlives;
    	}
    }
}
