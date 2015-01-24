using UnityEngine;
using System.Collections;

public class CS_Numbers : MonoBehaviour
{
	public CS_RandomNumber Numbers;
	public CS_PlayerHealth heatlth;

	public bool isTouched;

	public int NumberIndex;
	public int Number;


	// Use this for initialization
	void Start () 
	{
		Numbers = GameObject.Find ("GameState").GetComponent <CS_RandomNumber> ();
		heatlth = GameObject.Find ("Player's Health").GetComponent<CS_PlayerHealth> ();
		Number = Numbers.numbers[NumberIndex];
	}

	void Update ()
	{
		if (isTouched == true)
		{
			if (Input.GetButton("Fire1"))
			{
				if (Number <= 5)
				{
					heatlth.curHealth -= 20;
					print ("Oww!");
					isTouched = false;
				}

				else if (Number > 5 && (Number <= 8))
				{
					print ("You Saved Me!");
					isTouched = false;
				}

				else 
				{
					print ("It's Fucking Nothing");
					isTouched = false;
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
