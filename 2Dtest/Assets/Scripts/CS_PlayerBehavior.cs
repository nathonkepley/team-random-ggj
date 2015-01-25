using UnityEngine;
using System.Collections;

public class CS_PlayerBehavior : MonoBehaviour 
{
	public float walkSpeed = 2f;
    public float callLifetime = 2f;

    private CS_SpeechBehavior _speech;
    private CS_CallOutBehavior _callOut;
    private Animator _animator;
    private float _moveX, _moveY;
    private float _currentCallLifetime;

	// Use this for initialization
	void Start () 
    {
        _speech = this.GetComponentInChildren<CS_SpeechBehavior>();
        _callOut = this.GetComponentInChildren<CS_CallOutBehavior>();
        _speech.gameObject.SetActive(false);
        _callOut.gameObject.SetActive(false);
	    _animator = this.GetComponent<Animator>();
        _moveX = 0f;
        _moveY = 0f;
        _currentCallLifetime = 0f;
	}

    void FixedUpdate()
    {
        transform.Translate(_moveX * Time.deltaTime, _moveY * Time.deltaTime, 0.0f);
        renderer.sortingOrder = 1000 - (int)((transform.position.y - renderer.bounds.extents.y) * 100);

        if (_currentCallLifetime > 0f)
        {
            _currentCallLifetime -= Time.deltaTime;
            if (_currentCallLifetime <= 0f)
            {
                _speech.gameObject.SetActive(false);
                _callOut.gameObject.SetActive(false);
            }
        }
    }

    public void Move(float x, float y)
    {
        _moveX = x * walkSpeed;
        _moveY = y * walkSpeed;
        if ((x != 0f) || (y != 0f))
        {
            _animator.SetBool("moving", true);
            _animator.SetFloat("moveX", _moveX);
            _animator.SetFloat("moveY", _moveY);
        }
        else
        {
            _animator.SetBool("moving", false);
        }
    }

    public void Call()
    {
        _currentCallLifetime = callLifetime;
        _speech.gameObject.SetActive(true);
        _callOut.gameObject.SetActive(true);
    }
}
