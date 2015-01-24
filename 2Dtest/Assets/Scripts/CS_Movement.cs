using UnityEngine;
using System.Collections;

public class CS_Movement : MonoBehaviour 
{
	public float walkSpeed = 2f;

    private float _moveX, _moveY;
    private Animator _animator;

	// Use this for initialization
	void Start () 
    {
	    _animator = this.GetComponent<Animator>();
        _moveX = 0.0f;
        _moveY = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
        _moveX = Input.GetAxis("Horizontal") * walkSpeed;
        _moveY = Input.GetAxis("Vertical") * walkSpeed;

        if ((_moveX != 0f) || (_moveY != 0f))
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

    void FixedUpdate()
    {
        transform.Translate(_moveX * Time.deltaTime, _moveY * Time.deltaTime, 0.0f);
        //renderer.sortingOrder = 1000 - (int)((transform.position.y - renderer.bounds.extents.y) * 100);
    }

	void OnCollisionEnter(Collision other)
		{
			
		}

	void OnCollisionExit (Collision other)
		{
			
		}
}
