using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string myFirstScene;
    private Scene scene;

    void Start(){
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
    }
	//Level om te laden
    public void LoadScene(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    public void GameOver(){
        try {
            FindObjectOfType<AudioManager>().Play("Breaking");
        } catch {
            Debug.Log("Audomanager not found");
        }
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void DEAD(){
        SceneManager.LoadScene("GameOverScene");
        Destroy(gameObject);
    }
    public void LoadSceneDestroyManagement(string scenename) {
    	Time.timeScale = 1f;
        try {
            Destroy(GameObject.FindWithTag("Management"));
        }   catch {
            Debug.Log("Management doesn't exist, not destroying");
        }
        try {
            Destroy(GameObject.FindWithTag("Health"));
        } catch {
            Debug.Log("Health doesn't exist, not destroying");
        }
        try {
            Destroy(GameObject.FindWithTag("Score"));
        } catch {
            Debug.Log("Score doesn't exist, not destroying");
        }
        
        SceneManager.LoadScene(scenename);
    }
    public void WinLevel1(){
        SceneManager.LoadScene("Level2");
        Destroy(gameObject);
    }
    public void WinLevel2(){
        SceneManager.LoadScene("Level3");
        Destroy(gameObject);
    }
    public void WinLevel3(){
        SceneManager.LoadScene("WIN");
        Destroy(gameObject);
    }
}
