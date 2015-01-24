using UnityEngine;
using System.Collections;

public enum BubbleState { Marco, Polo }
public enum BubbleDirection { Left, Right }

public class CS_SpeechBehavior : MonoBehaviour {
    public BubbleState bubbleState = BubbleState.Marco;
    public BubbleDirection bubbleDirection = BubbleDirection.Right;
    public float minHover = 0f, maxHover = 0f, hoverSpeed = 0f;
    public float lifetime = 5f;

    private GameObject _bubble;
    private GameObject _marco;
    private GameObject _polo;
    private float _currentHover, _currentHoverSpeed;
    private float _currentLifetime;

	// Use this for initialization
	void Start ()
    {
        _bubble = GameObject.Find("Bubble");
        _marco = GameObject.Find("Marco");
        _polo = GameObject.Find("Polo");
        _currentHover = 0f;
        _currentHoverSpeed = hoverSpeed;
        _currentLifetime = lifetime;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (bubbleState == BubbleState.Marco)
        {
            _marco.renderer.enabled = true;
            _polo.renderer.enabled = false;
        }
        else
        {
            _marco.renderer.enabled = false;
            _polo.renderer.enabled = true;
        }

        if (bubbleDirection == BubbleDirection.Right)
        {
            _bubble.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            _bubble.transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        _currentHover += _currentHoverSpeed * Time.deltaTime;
        transform.position += new Vector3(0f, _currentHoverSpeed * Time.deltaTime, 0f);

        if (_currentHover >= maxHover)
        {
            _currentHover = maxHover;
            _currentHoverSpeed *= -1f;
        }

        if (_currentHover <= minHover)
        {
            _currentHover = minHover;
            _currentHoverSpeed *= -1f;
        }

        _currentLifetime -= Time.deltaTime;
        if (_currentLifetime <= 0f)
        {
            gameObject.SetActive(false);
        }
	}

    void Activate()
    {
        gameObject.SetActive(true);
        _currentLifetime = lifetime;
    }
}
