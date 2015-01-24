using UnityEngine;
using System.Collections;

public class CS_No : MonoBehaviour 
{
	public bool notOpened = false;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnClick ()
	{
		notOpened = true;
	}
}
