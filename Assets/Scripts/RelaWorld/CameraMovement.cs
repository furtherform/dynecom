using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// THIS IS THE CLASS FOR CONTROLLING THE CAMERA FOR THE VIDEO CAPTURE

	float speed = 1.5f;
	float turnspeed = 20.0f;
	public GameObject CameraToMove;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame


		void Update()
		{
			if(Input.GetKey(KeyCode.D))
			{
				transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
			}
			if(Input.GetKey(KeyCode.A))
			{
				transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
			}
			if(Input.GetKey(KeyCode.DownArrow))
			{
				transform.Translate(new Vector3(0,-speed / 2 * Time.deltaTime,0));
			}
			if(Input.GetKey(KeyCode.UpArrow))
			{
				transform.Translate(new Vector3(0,speed / 2 * Time.deltaTime,0));
			}

		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
		}


			if(Input.GetKey(KeyCode.E))
			{
			transform.Rotate(Vector3.up, turnspeed  * Time.deltaTime);
			}
		if(Input.GetKey(KeyCode.Q))
		{
			transform.Rotate(Vector3.down, turnspeed * Time.deltaTime);
			
		}

		if(Input.GetKey(KeyCode.N))
		{
			speed -= 0.1f;
		}

		if(Input.GetKey(KeyCode.M))
		{
			speed += 0.1f;
		}

		}
	

}
