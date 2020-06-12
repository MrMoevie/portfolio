using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updown : MonoBehaviour
{
	public float amount = 3;
    float timer;
    Vector3 position;

    void Start ()
    {
    	position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = position + new Vector3(0, Mathf.Sin(timer) * amount, 0);
    }
}
