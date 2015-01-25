using UnityEngine;
using System.Collections;

public enum BubbleState { Marco, Polo }
public enum BubbleDirection { Left, Right }

public class CS_SpeechBehavior : MonoBehaviour {
    public float minHover = 0f, maxHover = 0f, hoverSpeed = 0f;

    private float _currentHover, _currentHoverSpeed;
    
	// Use this for initialization
	void Start ()
    {
        _currentHover = 0f;
        _currentHoverSpeed = hoverSpeed;
	}
	
	// Update is called once per frame
	void Update ()
    {
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
	}
}
