using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         Quaternion player_rot = transform.parent.rotation;
         transform.rotation = player_rot;


     transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position -= new Vector3(0 , 0 , transform.position.z); //resets z to 0


        Cursor.visible = false;
    }
}
