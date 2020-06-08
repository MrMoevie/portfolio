using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
	public static bool GameIsPaused = false;

	public GameObject PauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        // als de terug knop is ingedrukt, pauzeer dan de game
        if (Input.GetKeyDown(KeyCode.Escape)) {
        	if (GameIsPaused) {
        		Resume();
        	} 
        	else {
        		Pause();
        	}
        }
    }

    public void Resume() {
        // Set de pause menu UI op actief en zet de game still
    	PauseMenuUI.SetActive(false);
    	Time.timeScale = 1f;
    	GameIsPaused = false;
    }
    public void Pause() {
        // Set de pause menu UI op inactief en herat de game weer
    	PauseMenuUI.SetActive(true);
    	Time.timeScale = 0f;
    	GameIsPaused = true;
    }
}
