using UnityEngine;
using System.Collections;

public class CS_HUD : MonoBehaviour 
{
    public CS_GameState state;
	
	// Update is called once per frame
	void Update () 
	{
        GameObject.Find("Health").GetComponent<GUIText>().text = state.curHealth + "/" + state.maxHealth;
        GameObject.Find("Saved").GetComponent<GUIText>().text = state.saved + "/" + state.canCollect;
	}
}
