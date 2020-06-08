using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicardoEvent : MonoBehaviour
{
    public bool eventstarted;
    AudioSource audioSource;
    // Start is called before the first frame update

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        eventstarted = true;

    }

    // Update is called once per frame
    void Update()
    {
        //Als de game is gepauzeerd pauseer de muziek
        if (PauseMenuScript.GameIsPaused) {
            audioSource.Pause();
        } else {
            audioSource.UnPause();
        }
        //Als de audio is is gestopt met spelen en de game is niet gepauzeerd
        if (!audioSource.isPlaying) {
            if (!PauseMenuScript.GameIsPaused) {
                //vernietig gameobject
                eventstarted = false;
                Destroy(gameObject);
            }
        }
    }
}
