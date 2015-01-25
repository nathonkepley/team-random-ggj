using UnityEngine;
using System.Collections;

public enum FurnitureContents { Monster1, Monster2, Monster3, Monster4, Friend1, Friend2, Friend3, Friend4, Nothing }

public class CS_FurnitureBehavior : MonoBehaviour
{
    public CS_GameState state;
    public bool isTouched;
    public FurnitureContents contents;
    public int done = 0;
	public GameObject buttons;
	public AudioClip baddieSound;
	public AudioClip buddieSound;
    public float callLifetime = 2f;
    public int buddyHeal = 20;
    public int baddieDamage = 50;

    public CS_SpeechBehavior _speech;
    private float _currentCallLifetime;

	void Update()
    {
        renderer.sortingOrder = 1000 - (int)((transform.position.y - renderer.bounds.extents.y) * 100);
    }

	void Start()
	{
        _speech = this.GetComponentInChildren<CS_SpeechBehavior>();
        _speech.gameObject.SetActive(false);
        _currentCallLifetime = 0f;

		buttons.SetActive (false);
	}

	void Awake ()
	{
		buttons = GameObject.Find ("Question Buttons");
	}

    void FixedUpdate()
    {
        if (_currentCallLifetime >= 0f)
        {
            _currentCallLifetime -= Time.deltaTime;
            if (_currentCallLifetime <= 0f)
            {
                _speech.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Player") && (other.isTrigger == false))
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
            case FurnitureContents.Monster1:
            case FurnitureContents.Monster2:
            case FurnitureContents.Monster3:
            case FurnitureContents.Monster4:
			audio.PlayOneShot(baddieSound, 0.7F);
            if (state.open == true)
				{
	                state.curHealth -= baddieDamage;
	                print("Oww!");
					renderer.material.color = Color.gray;
                    //state.gameMode = GameMode.Play;
                Time.timeScale = 1;
					buttons.SetActive (false);
					isTouched = false;
					done = 1;
                    state.open = false;
				}
			else
				{
					buttons.SetActive (true);
                    //state.gameMode = GameMode.Menu;
                Time.timeScale = 0;
				}

            if (state.notOpened == true)
			{
				buttons.SetActive (false);
                //state.gameMode = GameMode.Play;
                Time.timeScale = 1;
                state.notOpened = false;
				isTouched = false;
				done = 0;
			}

			break;

            case FurnitureContents.Friend1:
            case FurnitureContents.Friend2:
            case FurnitureContents.Friend3:
            case FurnitureContents.Friend4:
			audio.PlayOneShot(buddieSound, 0.7F);
            if (state.open == true)
				{
                    state.curHealth += buddyHeal;
	                state.saved += 1;
	                print("You Saved Me!");
					renderer.material.color = Color.gray;
                    //state.gameMode = GameMode.Play;
                Time.timeScale = 1;
					buttons.SetActive (false);
					isTouched = false;
					done = 1;
                    state.open = false;
				}
			else
				{
					buttons.SetActive (true);
                    //state.gameMode = GameMode.Menu;
                Time.timeScale = 0;
				}
            if (state.notOpened == true)
			{
				buttons.SetActive (false);
                //state.gameMode = GameMode.Play;
                Time.timeScale = 1;
				done = 0;
				isTouched = false;
                state.notOpened = false;
			}
                break;

            case FurnitureContents.Nothing:
                if (state.open == true)
				{
	                print("It's Nothing");
					renderer.material.color = Color.gray;
                    //state.gameMode = GameMode.Play;
                    Time.timeScale = 1;
					buttons.SetActive (false);
					isTouched = false;
					done = 1;
                    state.open = false;
				}
			else
				{
					buttons.SetActive (true);
                    //state.gameMode = GameMode.Menu;
                    Time.timeScale = 0;
				}
                if (state.notOpened == true)
			{
				buttons.SetActive (false);
                //state.gameMode = GameMode.Play;
                    Time.timeScale = 1;
                state.notOpened = false;
				isTouched = false;
				done = 0;
			}
			break;
        }
    }

    public void Call()
    {
        _currentCallLifetime = callLifetime;
        _speech.gameObject.SetActive(true);
    }
}
