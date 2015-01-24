using UnityEngine;
using System.Collections;

public enum FurnitureContents { Baddie, Buddy, Nothing }

public class CS_FurnitureBehavior : MonoBehaviour
{
    public CS_GameState state;
    public bool isTouched;
    public FurnitureContents contents;
    public int done = 0;

	void Update()
    {
        renderer.sortingOrder = 1000 - (int)((transform.position.y - renderer.bounds.extents.y) * 100);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouched = true;
        }
    }

    void OnTriggerEnter2D()
    {
        isTouched = false;
    }

    public void Activate()
    {
        switch (contents)
        {
            case FurnitureContents.Baddie:
                state.curHealth -= 20;
                print("Oww!");
                break;

            case FurnitureContents.Buddy:
                state.saved += 1;
                print("You Saved Me!");
                break;

            case FurnitureContents.Nothing:
                print("It's Fucking Nothing");
                break;
        }
        renderer.material.color = Color.gray;
        isTouched = false;
        done = 1;
    }
}
