using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTransform : MonoBehaviour {

	private string MoveInputAxis = "Vertical";
	private string TurnInputAxis = "Horizontal";

    // Divisor de velocidad de rotacion
    public float rotationRate = 2;

    // Divisor de velocidad de movimiento
    public float moveSpeed = 0.5f;

    // Deteccion de salto
    private bool m_Grounded;
    private float m_Fall, curr_height, last_height;

    // Animacion
    private Animation m_Animation;

    // Rigidbody
    private Rigidbody m_Rigidbody;


    private void Start()
    {
        m_Animation = GetComponentInChildren<Animation>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Grounded = true;
    }

    private void FixedUpdate()
    {
        float moveAxis = Input.GetAxis(MoveInputAxis);
        float turnAxis = Input.GetAxis(TurnInputAxis);
        //Tomo la altura actual y comparo
		curr_height = m_Rigidbody.transform.position.y;
        if (m_Grounded==false)
            m_Fall=(curr_height-last_height);
        //Actualización de la animacion
        //Salto
        if (Input.GetButtonDown("Jump"))
        {
            m_Animation.CrossFade("JumpSW");
			m_Rigidbody.AddForce (transform.up * 20);
            m_Grounded = false;
        }
        //Movimiento
        else if (moveAxis > 0 && m_Grounded == true)
        {
            m_Animation.CrossFade("WalkSW");
            ApplyInput(moveAxis, turnAxis);
        }
        //giro
        else if (moveAxis == 0 && m_Grounded == true)
        {
            m_Animation.CrossFade("IdleSW");
            ApplyInput(0, turnAxis);
        }
        //Caída
        else if (m_Fall<0 && m_Grounded == false)
        {
			m_Animation.CrossFade ("WalkSW");
            m_Grounded = true;//TODO: ver porque no se activa de nuevo
        }
        else if (moveAxis == 0 && turnAxis ==0 && m_Grounded == true)
        {
            m_Animation.CrossFade("IdleSW");
        }

        //Actualizo la altura actual de nuevo
		last_height=curr_height;
    }

    private void ApplyInput(float moveInput,
                            float turnInput) 
    {
		Move(moveInput);
		Turn(turnInput);
    }

    private void Move(float input) 
    {
		transform.Translate(Vector3.forward * input * moveSpeed);
	}

    private void Turn(float input)
    {
        transform.Rotate(0, input / rotationRate, 0);
    }


}