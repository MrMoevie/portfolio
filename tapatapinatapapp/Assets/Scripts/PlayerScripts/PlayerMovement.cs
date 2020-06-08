using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private int state = 0;
	public int position = 0;
	private Vector3 fp;   // First touch position
	private Vector3 lp;   // Last touch position
	private float dragDistance;  // Minimum distance for a swipe to be registered
	public GameObject bottle; // De bottle om te gebruiken in de level
	public Animator animator; // De animator
	private Vector3 Offset;
	private bool goingleft = false;
	public float speed = 2f;
	private bool AnimationEnded = false;
	private bool locked;

	void Start() {
	   dragDistance = Screen.height * 15 / 100; // dragDistance is 15% height of the screen
	   goingleft = false;
	}

	// Update is called once per frame
	void Update() { 
	 if (Input.touchCount == 1) // user is touching the screen with a single touch
	 {
			Touch touch = Input.GetTouch(0); // get the touch
			if (touch.phase == TouchPhase.Began) // check for the first touch
			{
				fp = touch.position;
				lp = touch.position;
			}
			else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
			{
				lp = touch.position;
			}
			else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
			{
				lp = touch.position;  //last touch position. Ommitted if you use list

				// Check if drag distance is greater than 20% of the screen height
				if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance) {

				 // check if the drag is vertical or horizontal
					if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
					{   // If the horizontal movement is greater than the vertical movement...
						if ((lp.x > fp.x))  // If the movement was to the right)
						{   // Right swipe
							goingleft = false;

						}
						else
						{   //Left swipe
							goingleft = true;
						}
					}
					else
					{   // the vertical movement is greater than the horizontal movement
						if (lp.y > fp.y)  // If the movement was up
						{   // Up swipe
							position += 1;
							goingleft = false;
						}
						else
						{   // Down swipe
							position -= 1;
							goingleft = false;
						}
					}
				}
				else
				{   // It's a tap as the drag distance is less than 20% of the screen height
				if(!locked) {
					state += 1;
					goingleft = false;
				}
			}
		}
	}

		// Keyboard controls voor makkelijker debuggen
	if(Input.GetKeyDown(KeyCode.UpArrow)) {
		position += 1;
		goingleft =false;
	}
	if(Input.GetKeyDown(KeyCode.DownArrow)) {
		position -= 1;
		goingleft = false;
	}
	if(Input.GetKeyDown(KeyCode.Space)) {
		if(!locked) {
			state += 1;
			goingleft = false;
		}
	}
	if(Input.GetKeyDown(KeyCode.LeftArrow)) {
		goingleft = true;
	}
	//Player constantly moves to the left
	if (goingleft == true){
		transform.Translate(new Vector3(-1,0,0) * speed * Time.deltaTime);
		state = 0;
	}else{
	   switch (position){ // moves the player position according to position
	   	case -1:
	   	position = 3;
	   	break;
	   	case 0:
	   	transform.position = new Vector2(4,-4);
	   	break;

	   	case 1:
	   	transform.position = new Vector2(4,-2);
	   	break;

	   	case 2:
	   	transform.position = new Vector2(4,0);
	   	break;

	   	case 3:
	   	transform.position = new Vector2(4,2);
	   	break;
	   	
	   	case 4:
	   	position = 0;
	   	break;
	   }
	}
	switch (state){ //makes bottle in 2 tap
		case 0:
			// PickingUp op false zetten zodat de idle animation speelt
		animator.SetBool("PickingUp", false);
		locked = false;
		break;
		case 1:
			// PickingUp op true zetten zodat de Pickup animation speelt
		animator.SetBool("PickingUp", true);
		locked = true;
		if(AnimationEnded) {
			AnimationEnded = false;
			locked = false;
			state = 2;
		}
		break;
		case 2:
		break;
		case 3:
		//create een bottle op de bar en zet de state weer op 0
		Offset = new Vector3(-1.5f,0.7f,0);
		Instantiate(bottle, transform.position + Offset, Quaternion.identity); 
		state = 0;
		break;
	}
}
// als de speler het einde van de bar bereikt ga ja terug
void OnTriggerEnter2D(Collider2D col) {
	if(col.gameObject.name == "PlayerCollider") {
		goingleft = false;
	}

}
//Als de bottle pak animatie klaar is met spelen
public void AlertObservers(string message) {
	if (message.Equals("AnimationEnd"))
	{
		AnimationEnded = true;
	}
}
}