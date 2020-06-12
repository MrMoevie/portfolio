using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
	public Rigidbody2D rb;
	public GameObject Explosion;
	public float propulsion;
	public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 20f;
        rb.velocity = transform.right * propulsion;
    }

    // Update is called once per frame
    void Update()
    {
    	time -= Time.deltaTime;
        if (time <= 0 ){
        	 Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
    	Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
