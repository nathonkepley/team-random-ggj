using UnityEngine;
using System.Collections;

public class CS_Movement : MonoBehaviour 
{
	public float Speed = 2f;
	public float runSpeed =    5f;



	// Use this for initialization
	void Start () 
		{
		
		}
	
	// Update is called once per frame
	void Update () 
		{

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Speed = runSpeed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Speed = 2f;
            }

        transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime
            , Input.GetAxis("Vertical") * Speed * Time.deltaTime
            , 0.0f);

        renderer.sortingOrder = 1000 - (int)((transform.position.y - renderer.bounds.extents.y) * 100);
        /*
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
        */
			
		}

	void OnCollisionEnter(Collision other)
		{
			
		}

	void OnCollisionExit (Collision other)
		{
			
		}
}
