using UnityEngine;
using System.Collections;

public class CS_CheckpointController : MonoBehaviour 
{
	public CS_PlayerHealth health;

	public Vector3 lastCheckpoint;
	public Vector3 curPosition;

	public GameObject player;


	// Use this for initialization
	void Start () 
	{
		health = GameObject.Find ("Player's Health").GetComponent<CS_PlayerHealth> ();
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		lastCheckpoint = curPosition;
		if (health.curHealth <= 0)
		{
			player.transform.position = lastCheckpoint;
			health.curHealth = health.maxHealth;
		}
	}
}
