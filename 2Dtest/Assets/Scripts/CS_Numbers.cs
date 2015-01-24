using UnityEngine;
using System.Collections;

public class CS_Numbers : MonoBehaviour
{
	public CS_RandomNumber Numbers;
	public CS_PlayerHealth heatlth;

	public bool isTouched;

	public int saved = 0;
	public int NumberIndex;
	public int Number;
	public int done = 0;


	// Use this for initialization
	void Start () 
	{
		Numbers = GameObject.Find ("GameState").GetComponent <CS_RandomNumber> ();
		heatlth = GameObject.Find ("Player's Health").GetComponent<CS_PlayerHealth> ();
		Number = Numbers.numbers[NumberIndex];
	}

	void Update ()
	{
		if (isTouched == true && done == 0)
		{
			if (Input.GetButton("Fire1"))
			{
				if (Number <= 5)
				{
					heatlth.curHealth -= 20;
					print ("Oww!");
					renderer.material.color = Color.gray;
					isTouched = false;
					done = 1;
				}

				else if (Number > 5 && (Number <= 8))
				{
					saved += 1;
					print ("You Saved Me!");
					renderer.material.color = Color.gray;
					isTouched = false;
					done = 1;
				}

				else 
				{
					print ("It's Fucking Nothing");
					renderer.material.color = Color.gray;
					isTouched = false;
					done = 1;
				}
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			isTouched = true;
		}
	}

	void OnTriggerEnter2D()
	{
		isTouched = false;
	}
}
