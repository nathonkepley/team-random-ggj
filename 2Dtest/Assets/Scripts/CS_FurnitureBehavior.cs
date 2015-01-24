using UnityEngine;
using System.Collections;

public enum FurnitureContents { Baddie, Buddy, Nothing }

public class CS_FurnitureBehavior : MonoBehaviour
{
    public CS_GameState state;
    public bool isTouched;
    public FurnitureContents contents;
    public int done = 0;
	public GameObject buttons;
	public AudioClip baddieSound;
	public AudioClip buddieSound;
	public CS_Yes opened;
	public CS_No nope;


	void Update()
    {
        renderer.sortingOrder = 1000 - (int)((transform.position.y - renderer.bounds.extents.y) * 100);
    }

	void Start()
	{
		buttons.SetActive (false);
		opened = GameObject.Find ("Question Manager").GetComponent <CS_Yes>();
		nope = GameObject.Find ("Question Manager").GetComponent <CS_No> ();
	}

	void Awake ()
	{
		buttons = GameObject.Find ("Question Buttons");
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
			audio.PlayOneShot(baddieSound, 0.7F);
			if (opened.open == true)
				{
	                state.curHealth -= 20;
	                print("Oww!");
					renderer.material.color = Color.gray;
					Time.timeScale = 1;
					buttons.SetActive (false);
					isTouched = false;
					done = 1;
					opened.open = false;
				}
			else
				{
					buttons.SetActive (true);
					Time.timeScale = 0;
				}
			if (nope.notOpened == true)
			{
				buttons.SetActive (false);
				Time.timeScale = 1;
				nope.notOpened = false;
				isTouched = false;
				done = 0;
			}

			break;

            case FurnitureContents.Buddy:
			audio.PlayOneShot(buddieSound, 0.7F);
			if (opened.open == true)
				{
	                state.saved += 1;
	                print("You Saved Me!");
					renderer.material.color = Color.gray;
					Time.timeScale = 1;
					buttons.SetActive (false);
					isTouched = false;
					done = 1;
					opened.open = false;
				}
			else
				{
					buttons.SetActive (true);
					Time.timeScale = 0;
				}
			if (nope.notOpened == true)
			{
				buttons.SetActive (false);
				Time.timeScale = 1;
				done = 0;
				isTouched = false;
				nope.notOpened = false;
			}
                break;

            case FurnitureContents.Nothing:
			if (opened.open == true)
				{
	                print("It's Nothing");
					renderer.material.color = Color.gray;
					Time.timeScale = 1;
					buttons.SetActive (false);
					isTouched = false;
					done = 1;
					opened.open = false;
				}
			else
				{
					buttons.SetActive (true);
					Time.timeScale = 0;
				}
			if (nope.notOpened == true)
			{
				buttons.SetActive (false);
				Time.timeScale = 1;
				nope.notOpened = false;
				isTouched = false;
				done = 0;
			}
			break;
        }
    }
}
