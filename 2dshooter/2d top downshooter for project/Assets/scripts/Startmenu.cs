using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void onclick_start () {
        SceneManager.LoadScene("level 1", LoadSceneMode.Single);
    }
    public void onclick_endless () {
        SceneManager.LoadScene("endless", LoadSceneMode.Single);
    }
}
