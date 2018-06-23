using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    //Ejes de movimiento
    private string MoveInputAxis = "Vertical";
    private string TurnInputAxis = "Horizontal";
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public float jumpSpeed = 0.05F;
    public float runSpeed = 2.5F;
    public float windSpeed = 1.00F;
    bool wind;
    float curSpeed;

    // Animacion
    private Animation m_Animation;
    private Rigidbody rb;
    private void Start()
    {
        m_Animation = GetComponentInChildren<Animation>();
        rb = GetComponentInChildren<Rigidbody>();

    }
    void FixedUpdate()
    {
        float moveAxis = Input.GetAxis(MoveInputAxis);
        float turnAxis = Input.GetAxis(TurnInputAxis);
        CharacterController controller = GetComponent<CharacterController>();
        
        //Movimiento
		if (!wind) {
			transform.Rotate(0, turnAxis * rotateSpeed, 0);
			windSpeed = 1.00F;
		}
        if (wind)
        {
            windSpeed = Random.Range(-0.1f, 0.8f);
            rb.AddForce(-6, 0, 0);
        }
        Vector3 forward = transform.TransformDirection(Vector3.forward);
		Vector3 up = transform.TransformDirection(Vector3.up);

        curSpeed = speed * moveAxis * runSpeed;
        controller.SimpleMove(forward * curSpeed * windSpeed);

        //Animacion
        //Salto
		if (Input.GetButtonDown("Jump") && controller.isGrounded && !wind)
        {
            m_Animation.Play("JumpSW");
            controller.Move(up * jumpSpeed);     
        }
        //Movimiento
        else if (moveAxis > 0 && controller.isGrounded)
        {
            if (Input.GetButton("Run"))
            {
                runSpeed = 2.5F;
                m_Animation.CrossFade("RunSW");
            }
            else
            {
                runSpeed = 1.00F;
                m_Animation.CrossFade("WalkSW");
            }
        }

        //giro
		else if (moveAxis == 0 && controller.isGrounded && !wind)
        {
            m_Animation.CrossFade("Idle");
        }
        //Caída
        else if (!controller.isGrounded)
        {
            m_Animation.CrossFade("WalkSW");
        }
        else if (moveAxis == 0 && turnAxis == 0 && controller.isGrounded)
        {
            m_Animation.CrossFade("Idle");
        }
        //Movimiento hacia atras
    }
    public void InsideWindzone()
    {
        wind=true;
    }
    public void OutsideWindzone()
    {
        wind=false;
    }
}