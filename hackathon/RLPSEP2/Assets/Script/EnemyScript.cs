using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 1;
    public string Tag;
    public float offset = 90;
    public Rigidbody2D rb;
    public float walkingspeed;
    public Transform attacktarget;    
    private Transform target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    public GameObject ammocrate;
    void Start () 
    {

    }
    void OnTriggerStay2D(Collider2D col) 
    {
      if(col.tag == "Planet")
      {
          Debug.Log("YeS");
          target = col.GetComponent<Transform>();
          }if(col.tag == "Player")
          {
              Debug.Log("YaS");
              attacktarget = col.GetComponent<Transform>();
          }
      }
      void OnTriggerExit2D(Collider2D col) 
      {
          if(col.tag == "Planet")
          {
              Debug.Log("NeS");
              target = null;
              }if(col.tag == "Player")
              {
                  Debug.Log("NaS");
                  attacktarget = null;        }
              }
              void Update(){
                if(health <= 0){
                    Instantiate(ammocrate, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                if(attacktarget != null){
                   var relativePoint = transform.InverseTransformPoint(attacktarget.position);
                   if (relativePoint.x < 0.0){
                    rb.AddRelativeForce(Vector2.left * walkingspeed);
                }
                else if (relativePoint.x > 0.0){
                    rb.AddRelativeForce(Vector2.right * walkingspeed);
                }
            }
        }
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
