using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{

	void Update ()
	{
		if(Input.GetKeyDown("space") || Input.GetButtonDown("Fire2")) reload();
	}
    public void reload()
    {
    	if(SceneManager.GetActiveScene().name != "Level") return;
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Starto()
    {
    	SceneManager.LoadScene("Level");
    }
}
