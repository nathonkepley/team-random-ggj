using UnityEngine;
using System.Collections;

public class CS_PlayerHealth : MonoBehaviour 
{
	public int curHealth = 100;
	public int maxHealth = 100;

	public GameObject plyHealth;
	public CS_Checkpoints checkpoint;

	// Use this for initialization
	void Start () 
	{
		plyHealth = GameObject.Find ("Player's Health"); 

		if (curHealth <= 0)
		{
			curHealth = 0;
			Application.LoadLevel ("2d_1");
		}

		if (curHealth >= 100)
		{
			curHealth = 100;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		guiText.text = curHealth + "/" + maxHealth;
	}
}
