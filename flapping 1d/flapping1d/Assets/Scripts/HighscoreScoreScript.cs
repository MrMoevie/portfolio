using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreScoreScript : MonoBehaviour
{
	public flapper flap;
    public float score;
    public int roundedscore;
    private GameObject berd;
    public Text scoreboard;

    private int last_score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(flap.amideadyet == false){
        roundedscore = Mathf.FloorToInt(score);
        //leeft berd nog zo niet stop met optellen
        score += Time.deltaTime;
        scoreboard.text = "SCORE " + roundedscore.ToString ();

        //scaling effect (wordt groter wanneer voorbij 10 20 30 etc)
        if(last_score != Mathf.FloorToInt(score / 10)) 
        {
            transform.localScale *= 2;
            transform.position += new Vector3(200, -20, 0);
            GetComponent<AudioSource>().Play();
        }else{ //change back to normal
            transform.localScale = Vector3.Lerp( transform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 4);
            transform.position = Vector3.Lerp( transform.position, new Vector3(258, 572, 0), Time.deltaTime*4);
        }
        last_score = Mathf.FloorToInt(score / 10);
        
    }}
}
