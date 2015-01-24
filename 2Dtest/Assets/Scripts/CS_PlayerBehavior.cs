using UnityEngine;
using System.Collections;

public class CS_PlayerBehavior : MonoBehaviour 
{
	public float walkSpeed = 2f;

    private Animator _animator;
    private float _moveX, _moveY;

	// Use this for initialization
	void Start () 
    {
	    _animator = this.GetComponent<Animator>();
        _moveX = 0f;
        _moveY = 0f;
	}

    void FixedUpdate()
    {
        transform.Translate(_moveX * Time.deltaTime, _moveY * Time.deltaTime, 0.0f);
        renderer.sortingOrder = 1000 - (int)((transform.position.y - renderer.bounds.extents.y) * 100);
    }

	void OnCollisionEnter(Collision other)
		{
			
		}

	void OnCollisionExit (Collision other)
		{
			
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
}
