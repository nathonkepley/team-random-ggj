using UnityEngine;
using System.Collections;

public class CS_Baddies : MonoBehaviour 
{
	public CS_Numbers number;

	// Use this for initialization
	void Start () 
	{
		number = GameObject.Find ("Crate").GetComponent <CS_Numbers>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
