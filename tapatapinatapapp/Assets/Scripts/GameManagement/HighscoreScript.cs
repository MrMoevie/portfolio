using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreScript : MonoBehaviour
{
	public static HighscoreScript instance;
	public int points = 0;
    public float bonuspoints = 1000;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        bonuspoints = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        bonuspoints -= Time.deltaTime;
    }
}
