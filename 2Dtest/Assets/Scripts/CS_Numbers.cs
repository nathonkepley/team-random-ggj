using UnityEngine;
using System.Collections;

public class CS_Numbers : MonoBehaviour
{
	public CS_RandomNumber Numbers;
	public CS_PlayerBehavior player;

	public bool isTouched;

	public int NumberIndex;
	public int Number;


	// Use this for initialization
	void Start () 
	{
		Numbers = GameObject.Find ("GameState").GetComponent <CS_RandomNumber> ();
		Number = Numbers.numbers[NumberIndex];
	}

	void Update ()
	{
		
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

    void PlayerInteract()
    {
        if (isTouched == true)
        {
            if (Number <= 5)
            {
                player.curHealth -= 20;
                print("Oww!");
                isTouched = false;
            }

            else if (Number > 5 && (Number <= 8))
            {
                print("You Saved Me!");
                isTouched = false;
            }

            else
            {
                print("It's Fucking Nothing");
                isTouched = false;
            }
        }
    }
}
