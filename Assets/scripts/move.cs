using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	public bool grounded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// "GROUNDED" check, let's raycast downwards to see if there is a 
		// floor collider beneath us
		Ray ray = new Ray( transform.position, new Vector3(0,-1,0) );
		
		if ( Physics.Raycast ( ray, 1.1f ) ) {
			grounded = true;
		} else {
			grounded = false;
		}
	}
	
	public float speed = 300f;

	
	// FixedUpdate is called once per physics frame
	void FixedUpdate () {
		// "GetAxis" returns a float from -1 to 1
		// from a "virtual joystick"...
		float x = Input.GetAxis ("Horizontal"); // imagine [A] = -1, [D] = +1
		float y = Input.GetAxis ("Vertical"); // imagine [W] = +1, [S] = -1
		
		// move player
		Rigidbody rbody = GetComponent<Rigidbody> ();
		rbody.AddRelativeForce (x * speed * Time.deltaTime, 0f, y * speed * Time.deltaTime);

		//jump
		if(Input.GetKeyDown (KeyCode.Space) && grounded == true)
		{
			rbody.AddRelativeForce (0f, 500f, 0f);
		}

	}
}