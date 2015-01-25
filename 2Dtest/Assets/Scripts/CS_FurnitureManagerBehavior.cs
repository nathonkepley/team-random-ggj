using UnityEngine;
using System.Collections;

public class CS_FurnitureManagerBehavior : MonoBehaviour
{
    public int numBaddies;
    public int numBuddies;

    CS_FurnitureBehavior[] _furniture;

    void Awake()
    {
        _furniture = FindObjectsOfType<CS_FurnitureBehavior>();

        int n = _furniture.Length;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            CS_FurnitureBehavior value = _furniture[k];
            _furniture[k] = _furniture[n];
            _furniture[n] = value;
        }

        for (int i = 0; i < numBaddies; i++)
        {
            _furniture[i].contents = FurnitureContents.Baddie;
        }

        for (int i = numBaddies; i < numBaddies + numBuddies; i++)
        {
            _furniture[i].contents = FurnitureContents.Buddy;
        }

        for (int i = numBaddies + numBuddies; i < _furniture.Length; i++)
        {
            _furniture[i].contents = FurnitureContents.Nothing;
        }
    }

    public void PlayerActivated()
    {
        int i = 0;
        while (i < _furniture.Length)
        {
            if (_furniture[i].isTouched)
            {
                _furniture[i].Activate();
                break;
            }

            i++;
        }
    }
}


