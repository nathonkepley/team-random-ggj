using UnityEngine;
using System.Collections;

public class CS_CollectableCounter : MonoBehaviour 
{
	public CS_Numbers safe;

	public int collected;
	
	public int canCollect = 3;

	// Use this for initialization
	void Start () 
	{
		safe = GameObject.FindWithTag ("Hide Spots").GetComponent <CS_Numbers>();
		collected = safe.saved;
	}
	
	// Update is called once per frame
	void Update () 
	{
		guiText.text = collected + "/" + canCollect;
		print ("One");
	}
}
