using UnityEngine;
using System.Collections;

public class CS_Checkpoints : MonoBehaviour 
{
	public bool isTouched;
	public int checkpointProgress = 0;

	public CS_CheckpointController cControl;
	
	void Start () 
	{
		cControl = GameObject.Find ("GameState").GetComponent <CS_CheckpointController>();
	}

	void Update () 
	{
//---Use past checkpoints by commenting out line 20 & removing checkpointProgress from this "if" statement---//
		if (isTouched == true && checkpointProgress == 0)
		{
			checkpointProgress = checkpointProgress + 1;
			cControl.curPosition = gameObject.transform.position;
		}
	}

	void OnTriggerEnter (Collider other)
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
