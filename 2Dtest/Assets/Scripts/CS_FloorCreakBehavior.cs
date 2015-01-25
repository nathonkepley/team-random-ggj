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
                isTouched = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if ((other.gameObject.tag == "Player") && (other.isTrigger == false))
		{
			isTouched = true;
		}
	}

	void OnTriggerExit2D()
	{
		isTouched = false;
	}
}
