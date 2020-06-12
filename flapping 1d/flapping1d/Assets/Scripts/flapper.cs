using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flapper : MonoBehaviour
{
	public GameObject box;
	public GameObject canvas;
	public float velocity;
	public float position;
	public bool amideadyet;

	public float offset;

	public AudioSource audio;
	public AudioClip death;

	


    // Start is called before the first frame update
    void Start()
    {
    	audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    	//add velocity to position
        position += velocity * Time.deltaTime;

        //jump
        if((Input.GetKeyDown("space") || Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0)) && !amideadyet) {
        	velocity = 8;
        	audio.Play();
        }

        //makes player fall
        velocity -= Time.deltaTime * 22f;

        //sets position to include levelbox position changes
        position -= box.GetComponent<levelbox>().distance;
        position -= offset;

        //places flapper on table
        transform.position = box.transform.position + (box.transform.rotation * new Vector3(0, position, 0));
        transform.position -= new Vector3(0, 0, transform.position.z + 5);
        transform.rotation = box.transform.rotation;


        //the length of the box
        float box_length = box.transform.localScale.y / 2;
        //the length of the flapper
        float flap_length = 1;

        //checks if flapper is hitting the under side of the box
        if( position - flap_length < -box_length && velocity < 0) {
        	velocity =0;
        	position = (-box_length) + flap_length;
        	canvas.gameObject.SetActive(true);
        	amideadyet = true;
        }
        
        //checks if flapper is hitting the upper side of the box
        if( position + flap_length > box_length && velocity > 0)
        {
        	velocity = 0;
        	position = box_length - flap_length;
        	canvas.gameObject.SetActive(true);
        	amideadyet = true;
        }

        if(amideadyet && audio.clip != death)
        {
        	audio.clip = death;
        	audio.Play();
        }


        //reverts changes done to position
        position += box.GetComponent<levelbox>().distance;
        position += offset;

    }
}
