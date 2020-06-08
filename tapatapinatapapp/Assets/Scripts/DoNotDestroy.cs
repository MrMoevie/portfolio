using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
void Awake()
    {

    	//Vind alle game objecten met de tag Music
        GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);
        //Is er meer dan 1 object met Music?
        if (objs.Length > 1)
        {
        	//Vernietig deze object en speel de nieuwe Audio Source af
            Destroy(this.gameObject);
        }
        //Vernietig deze object niet
        DontDestroyOnLoad(this.gameObject);
    }
}
