using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	
	//Level om te laden
    public void LoadScene(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    public void GameOver(){
    	Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
    }

}
