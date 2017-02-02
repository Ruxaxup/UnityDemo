using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private int direction;
    public int speed;
    private Animator _animator;
    public int jumpSpeed;
    
    //Estados
    public enum States
    {
        START,
        GAME,
        JUMPING,
        FALLING,
        SHOOTING,
        ENDGAME
    }
    //El estado del personaje con respecto al juego
    private int primaryState;
    private bool isJumping;
    private bool isGrounded;
    private Vector3 originalPosition;

    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
        primaryState = (int)States.START;
	}
	
	// Update is called once per frame
	void Update () {
        switch(primaryState)
        {
            //Todo lo que hace el personaje al empezar el nivel, por ejemplo, alguna animacion de presentacion
            case (int)States.START:
                //Do something
                primaryState = (int)States.GAME;
                break;
            //El usuario tiene el control del personaje
            case (int)States.GAME:
                Debug.Log("GameState");
                //Dentro puede haber diferentes estados como: saltar, caer, disparar, moverse a los lados (si no es un runer)
                if (GetDirection() != 0)
                {
                    //Debug.Log("Run");
                    _animator.Play("CubeRun");
                    //Debug.Log(direction);
                    transform.Translate(Vector3.right * Time.deltaTime * speed * direction);
                }
                //Si puede brincar y no esta saltando
                if (CanJump() && !isJumping)
                {
                    //Si se presiona la barra espaciadora decimos que esta saltando
                    if(Input.GetKey(KeyCode.Space))
                    {
                        isJumping = true;
                        Debug.Log("Jump");
                        _animator.Play("CubleJump");
                        originalPosition = transform.position;
                    }
                }
                if(isJumping)
                {
                    Jump();
                }
                if(!isJumping && !isGrounded)
                {
                    transform.Translate(Vector3.down * Time.deltaTime * jumpSpeed);
                }
                if (GetDirection() == 0 && !CanJump())
                {
                    //Debug.Log("Idle");
                    _animator.Play("CubeIdle");
                }
                break;
            //El nivel termino, haya ganado o perdido
            case (int)States.ENDGAME:
                Debug.Log("EndLevelState");                
                break;
            default:
                break;
        }
        
        
    }

    int GetDirection()
    {        
        direction = (int)Input.GetAxisRaw("Horizontal");
        return direction;
    }
    
    bool CanJump()
    {        
        return isGrounded;
    }

    void Jump()
    {
        if (transform.position.y < originalPosition.y + 3.2f)
        {
            transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed);
        }
        else
        {
            isJumping = false;            
        }  
    }

    public void EndLevelState()
    {
        Debug.Log("EndLevelState");
        _animator.Play("CubeEndingAnimation");
        primaryState = (int)States.ENDGAME;
    }

    void OnCollisionStay(Collision other)
    {
        isGrounded = true;
        isJumping = false;
    }

    void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }

    void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
        isJumping = false;
    }
}
