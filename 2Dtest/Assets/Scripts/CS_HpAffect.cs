using UnityEngine;
using System.Collections;

public class CS_HpAffect : MonoBehaviour 
{
    public CS_GameState state;

	public int damageDone;
	public int hpGained;

	public bool isTouched;
	
	// Update is called once per frame
	void Update () 
	{
		if (isTouched == true)
		{
            state.curHealth = state.curHealth - damageDone;

			if (gameObject.tag == "Enemy")
			{
				gameObject.SetActive (false);
			}
		}

		if (isTouched == true)
		{
            state.curHealth = state.curHealth + hpGained;
			
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
