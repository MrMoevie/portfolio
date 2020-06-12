using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{

	public GameObject box;
	public bool end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
    	float box_length = box.transform.localScale.y / 2;
    	float position = end ? (-box_length) + 0.5f : box_length - 0.5f;
        transform.position = box.transform.position + (box.transform.rotation * new Vector3(0, position, 0));
        transform.position -= new Vector3(0, 0, transform.position.z + 5);
        transform.rotation = box.transform.rotation;

        if(!end)
        {
        	transform.eulerAngles += new Vector3(0, 0, 180);
        }
    }
}
