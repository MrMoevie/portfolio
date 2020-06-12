using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Controller : MonoBehaviour
{   
    public GameObject menu;
    public string level;
    public int score = 0;
    void Start () {
        menu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GameObject.FindWithTag("Score").GetComponent<Text>().text = "" +  score;
        GameObject player = GameObject.Find("Player");
        if(player == null || menu.activeSelf){
            menu.SetActive(true);
            if(Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.JoystickButton0)){
                Respawn();
            }
            if(Input.GetKeyDown(KeyCode.JoystickButton6) || Input.GetKeyDown(KeyCode.JoystickButton1)){
                Quit();
            }
        }
        if(player != null && (Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.Escape))) {
            if(!menu.activeSelf) {
                menu.SetActive(true);
            }else {
                menu.SetActive(false);
            }
        }
        
        
    }

    public void Respawn () {
        DontDestroyOnLoad(this.gameObject);
        score -= 100;
        if(score < 0) {
            score = 0;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    public void Quit () {
        SceneManager.LoadScene("startmenu", LoadSceneMode.Single);
    }
}
