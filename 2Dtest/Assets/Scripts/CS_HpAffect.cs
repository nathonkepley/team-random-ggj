using UnityEngine;
using System.Collections;

public class CS_HpAffect : MonoBehaviour 
{
	public CS_PlayerHealth health;

	public int damageDone;
	public int hpGained;

	public bool isTouched;

	// Use this for initialization
	void Start ()
	{
		health = GameObject.Find ("Player's Health").GetComponent<CS_PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isTouched == true)
		{
			health.curHealth = health.curHealth - damageDone;

			if (gameObject.tag == "Enemy")
			{
				gameObject.SetActive (false);
			}
		}

		if (isTouched == true)
		{
			health.curHealth = health.curHealth + hpGained;
			
			if (gameObject.tag == "Enemy")
			{
				gameObject.SetActive (false);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			isTouched = true;
		}
	}

	void OnTriggerExit ()
	{
		isTouched = false;
	}
}
