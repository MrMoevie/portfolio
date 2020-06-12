using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
	public float time = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0f){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col) 
    {
       if(col.tag == "Enemy")
       {
           Debug.Log("YeS");
           col.GetComponent<GiveDamage>().health -= 1;
       }
   }
}
