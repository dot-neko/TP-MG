using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    //Ejes de movimiento
    private readonly string MoveInputAxis = "Vertical";
    private readonly string TurnInputAxis = "Horizontal";
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public float jumpSpeed = 0.05F;
    public float runSpeed = 1.00F;
    public float windSpeed = 1.00F;
    float nspeed = 1.00F, pspeed = 1.50F;
    bool wind, death;
    

    // Animacion
    private Animation m_Animation;
    private void Start()
    {
        m_Animation = GetComponentInChildren<Animation>();

    }
    void FixedUpdate()
    {
        float curSpeed;
        float moveAxis = Input.GetAxis(MoveInputAxis);
        float turnAxis = Input.GetAxis(TurnInputAxis);
        CharacterController controller = GetComponent<CharacterController>();

        //Movimiento
        if (death)
        {
            moveAxis = 0.0f;
            turnAxis = 0.0f;
        }
        if (!wind && !death)
        {
            windSpeed = 1.00F;
        }
        if (wind && !death)
        {
            windSpeed = Random.Range(-0.1f, 0.8f);
        }
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 up = transform.TransformDirection(Vector3.up);

        transform.Rotate(0, turnAxis * rotateSpeed, 0);
        curSpeed = speed * moveAxis * runSpeed;
        controller.SimpleMove(forward * curSpeed * windSpeed);

        //Animacion
        //Salto
        if (Input.GetButtonDown("Jump") && controller.isGrounded && !wind && !death)
        {
            m_Animation.Play("JumpSW");
            controller.Move(up * jumpSpeed);
        }
        //Movimiento
        else if (moveAxis > 0 && controller.isGrounded && !death)
        {
            if (Input.GetButton("Run"))
            {
                runSpeed = pspeed;
                m_Animation.CrossFade("RunSW");
            }
            else
            {
                runSpeed = nspeed;
                m_Animation.CrossFade("WalkSW");
            }
        }

        //giro
        else if (moveAxis == 0 && controller.isGrounded && !wind && !death)
        {
            m_Animation.CrossFade("Idle");
        }
        //Caída
        else if (!controller.isGrounded && !death)
        {
            m_Animation.CrossFade("WalkSW");
        }
        else if (moveAxis == 0 && turnAxis == 0 && controller.isGrounded && !death)
        {
            m_Animation.CrossFade("Idle");
        }
        //Movimiento hacia atras
    }
    public void InsideWindzone()
    {
        wind = true;
    }
    public void OutsideWindzone()
    {
        wind = false;
    }
    public void Death()
    {
        death = true;
    }
    public void Powerup()
        /*Aumenta la velocidad a la hora de correr*/
    {
        pspeed = pspeed * 1.3f;
    }
}