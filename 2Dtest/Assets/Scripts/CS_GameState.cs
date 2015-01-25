using UnityEngine;
using System.Collections;

public enum GameMode { Play, Menu }

public class CS_GameState : MonoBehaviour 
{
    public GameMode gameMode = GameMode.Play;
    public int curHealth = 100;
    public int maxHealth = 100;
    public int saved = 0;
    public int timeHealAmount = 1;
    public float timeHealCooldown = 3;

    public bool open = false;
    public bool notOpened = false;

    public CS_FurnitureManagerBehavior furnitureManager;
    public int canCollect = 4;

    private float _currentTimeHeal = 0f;

    // Use this for initialization
    void Update()
    {
        _currentTimeHeal += Time.deltaTime;
        if (_currentTimeHeal >= timeHealCooldown)
        {
            _currentTimeHeal = 0f;
            curHealth += timeHealAmount;
        }

        if (curHealth <= 0)
        {
            curHealth = 0;
            Application.LoadLevel("2d_1");
        }

        if (curHealth >= maxHealth)
        {
            curHealth = maxHealth;
        }
    }
}
