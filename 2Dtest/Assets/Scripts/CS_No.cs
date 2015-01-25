using UnityEngine;
using System.Collections;

public class CS_No : MonoBehaviour 
{
    public CS_GameState state;

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
		state.notOpened = true;
	}
}
