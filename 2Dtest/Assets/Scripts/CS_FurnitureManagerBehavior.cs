using UnityEngine;
using System.Collections;

public class CS_FurnitureManagerBehavior : MonoBehaviour
{
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

        _furniture[0].contents = FurnitureContents.Monster1;
        _furniture[1].contents = FurnitureContents.Monster2;
        _furniture[2].contents = FurnitureContents.Monster3;
        _furniture[3].contents = FurnitureContents.Monster4;

        _furniture[4].contents = FurnitureContents.Friend1;
        _furniture[5].contents = FurnitureContents.Friend2;
        _furniture[6].contents = FurnitureContents.Friend3;
        _furniture[7].contents = FurnitureContents.Friend4;

        for (int i = 8; i < _furniture.Length; i++)
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


