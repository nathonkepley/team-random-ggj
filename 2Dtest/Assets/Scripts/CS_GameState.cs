using UnityEngine;
using System.Collections;

public enum GameMode { Play, Menu }

public class CS_GameState : MonoBehaviour 
{
    public GameMode gameMode = GameMode.Play;
    public int curHealth = 100;
    public int maxHealth = 100;
    public int saved = 0;

    public bool open = false;
    public bool notOpened = false;

    public CS_FurnitureManagerBehavior furnitureManager;
    public int canCollect;

    void Start()
    {
        canCollect = furnitureManager.numBuddies;
    }

    // Use this for initialization
    void Update()
    {
        if (curHealth <= 0)
        {
            curHealth = 0;
            Application.LoadLevel("2d_1");
        }

        if (curHealth >= 100)
        {
            curHealth = 100;
        }
    }
}
