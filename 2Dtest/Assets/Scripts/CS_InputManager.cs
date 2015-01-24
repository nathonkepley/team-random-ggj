using UnityEngine;
using System.Collections;

public class CS_InputManager : MonoBehaviour
{
    public CS_PlayerBehavior player;
    public CS_FurnitureManagerBehavior furnitureManager;
	
	// Update is called once per frame
	void Update ()
    {
	    player.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetButton("Fire1"))
        {
            furnitureManager.PlayerActivated();
        }

        if (Input.GetButton("Fire2"))
        {
            player.Call();
        }
	}
}
