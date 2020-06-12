using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject curser = GameObject.Find("curser");
        transform.right = (curser.transform.position - transform.position);
        Vector3 rot = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(0, 0, rot.z - 90);

    }
}
