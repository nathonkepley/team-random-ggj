using UnityEngine;
using System.Collections;

public class CS_CameraFollow : MonoBehaviour 
{
	public GameObject Player;

	public Vector3 playerPosition;

	public float lockedZ = -12;

	// Use this for initialization
	void Start () 
	{
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerPosition = Player.transform.position;
		gameObject.transform.position = new Vector3 (playerPosition.x,playerPosition.y, lockedZ);
	}
}
