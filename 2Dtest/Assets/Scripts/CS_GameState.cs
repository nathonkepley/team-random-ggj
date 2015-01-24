using UnityEngine;
using System.Collections;

public class CS_GameState : MonoBehaviour 
{
    public int curHealth = 100;
    public int maxHealth = 100;
    public int saved = 0;
    public int canCollect = 3;

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
