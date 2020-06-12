using UnityEngine;

public class GunPointsMouse : MonoBehaviour
{
	public float offset = 20;
	public SpriteRenderer s_renderer;

	public Transform target;
	private Vector3 targetPos;
	private Vector3 thisPos;
	private float angle;
	void start() {
		GameObject cursor = GameObject.FindWithTag("cursor");
 
if(cursor != null)
{
      target = cursor.GetComponent<Transform>();
}
	}
	// Update is called once per frame
	void Update()
	{

		targetPos = target.position;
		thisPos = transform.position;
		targetPos.x = targetPos.x - thisPos.x;
		targetPos.y = targetPos.y - thisPos.y;
		angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

		if(gameObject.transform.localEulerAngles.z < 268 && gameObject.transform.localEulerAngles.z > 90) {
 			s_renderer.flipY = true;
 		} else {
 			s_renderer.flipY = false;
 		}
	}

}
