using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAwayFromPlanet : MonoBehaviour
{
	public string Tag;
	public float offset = 90;
	
	private Transform target;
	private Vector3 targetPos;
	private Vector3 thisPos;
	private float angle;
	
	void Start () 
	{
		
	}
	void OnTriggerEnter2D(Collider2D col) 
	{
		if(col.tag == "Planet")
		{
			Debug.Log("YeS");
			target = col.GetComponent<Transform>();
		}
	}
    //void OnTriggerExit2D(Collider2D col) 
   	//{
    //	 if(col.tag == "Planet")
    //	 {
    //	 Debug.Log("YeS");
    //     target = null;
    //    }
   // }
	void LateUpdate()
	{
		if(target != null){
			targetPos = target.position;
			thisPos = transform.position;
			targetPos.x = targetPos.x - thisPos.x;
			targetPos.y = targetPos.y - thisPos.y;
			angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
			}}
		}