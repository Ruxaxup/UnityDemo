using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private int direction;
    public int speed;
    private Animator _animator;
    public int jumpSpeed;
	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if(GetDirection() != 0)
        {
            Debug.Log("Run");
            _animator.Play("CubeRun");
            Debug.Log(direction);
            transform.Translate(Vector3.right * Time.deltaTime * speed * direction);
        }
        if(IsJumping())
        {
            //Debug.Log("Jump");
            Jump();
        }
        if(GetDirection() == 0 && !IsJumping())
        {
            //Debug.Log("Idle");
            _animator.Play("CubeIdle");
        }
        
        
    }

    int GetDirection()
    {        
        direction = (int)Input.GetAxisRaw("Horizontal");
        return direction;
    }

    bool IsJumping()
    {
        return Input.GetKey(KeyCode.Space);        
    }

    void Jump()
    {
        _animator.Play("CubleJump");
        transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed);
    }
}
