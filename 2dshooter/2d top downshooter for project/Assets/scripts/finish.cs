using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    // Start is called before the first frame update
    public string next_level;
    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            if(next_level == "") {
                Debug.Log("Error: No next level");
                return;
            }
            SceneManager.LoadScene(next_level, LoadSceneMode.Single);
        }
    }
}
