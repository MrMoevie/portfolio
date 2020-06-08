using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void GameQuitter(){
    Debug.Log("You Quit");
    Application.Quit();
    }
}
