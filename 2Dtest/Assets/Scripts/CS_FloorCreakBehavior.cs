using UnityEngine;
using System.Collections;

public class CS_FloorCreakBehavior : MonoBehaviour 
{
    public CS_GameState state;

	public int damageDone;

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
