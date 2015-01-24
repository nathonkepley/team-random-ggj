using UnityEngine;
using System.Collections;

public class CS_Movement : MonoBehaviour 
{
	public float Speed = 2f;
	public float jumpHeight = 100f;
	public float runSpeed =    5f;

	public bool Grounded;



	// Use this for initialization
	void Start () 
		{
		
		}
	
	// Update is called once per frame
	void Update () 
		{
			if (Input.GetKey (KeyCode.D))
				{
					transform.Translate (Vector2.right * Speed * Time.deltaTime);
					transform.eulerAngles = new Vector3 (0,0,0);
				}
			
			if (Input.GetKey (KeyCode.A))
				{
					transform.Translate (Vector2.right * Speed * Time.deltaTime);
					transform.eulerAngles = new Vector3 (0,180,0);
				}

			if (Input.GetKeyDown (KeyCode.LeftShift))
				{
					Speed = runSpeed;
					jumpHeight = 150;
				}
			if (Input.GetKeyUp (KeyCode.LeftShift))
				{
					Speed = 2f;
					jumpHeight = 100;
				}
			if (Grounded == true)
				{
					if (Input.GetKey (KeyCode.Space))
						{
							gameObject.rigidbody.AddForce (Vector3.up * jumpHeight);
						}
				}
		}

	void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.tag == "Ground")
				{
					Grounded = true;
				}
		}

	void OnCollisionExit (Collision other)
		{
			Grounded = false;
		}
}
