using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToText : MonoBehaviour
{
	public TextMeshProUGUI TextPro;
	public TextMeshProUGUI TextProf;
	private int lives;
	private int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	lives = GameObject.Find("HealthManagement").GetComponent<HealthScript>().lives;
    	score = GameObject.Find("Highscore").GetComponent<HighscoreScript>().points;

    	TextPro.text = "Lives " + lives.ToString();
        TextProf.text = "score " + score.ToString();
    }
}
