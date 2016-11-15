using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 5.0f;
    public float m_JumpSpeed = 4.0f;
    public float mouseSensitivity = 2.0f;

    [SerializeField]
    private Camera m_Camera;

    [SerializeField]
    private MyMouseLook m_MouseLook;

    [SerializeField]
    private float m_StickToGroundForce;

    [SerializeField]
    private float m_GravityMultiplier;

    [SerializeField]
    private bool m_Jump = false;

    [SerializeField]
    private bool m_Jumping = false;

    [SerializeField]
    private Vector2 m_Input = Vector2.zero;

    [SerializeField]
    private Vector3 m_MoveDir = Vector3.zero;

    [SerializeField]
    private CharacterController m_CharacterController;

    private bool m_PreviouslyGrounded = true;

    // Use this for initialization
    void Start() {
        m_Camera = Camera.main;
        m_CharacterController = GetComponent<CharacterController>();
        m_MouseLook.Init(transform, m_Camera.transform);
        m_StickToGroundForce = 10.0f;
        m_GravityMultiplier = 1.0f;
    }

    // Update is called once per frame
    void FixedUpdate() {
        m_MouseLook.LookRotation(transform, m_Camera.transform);

        if (!m_PreviouslyGrounded && m_CharacterController.isGrounded) {
            m_MoveDir.y = 0f;
            m_Jumping = false;
        }
        if (!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded) {
            m_MoveDir.y = 0f;
        }
        //Debug.Log("m_PreviouslyGrounded = " + m_PreviouslyGrounded);
        //Debug.Log("m_CharacterController.isGrounded = " + m_CharacterController.isGrounded);

        m_PreviouslyGrounded = m_CharacterController.isGrounded;


        float h = InputManager.GetAxis("Horizontal");
        float v = InputManager.GetAxis("Vertical");
        m_Input = new Vector2(h, v);
        if (m_Input.sqrMagnitude > 1) {
            m_Input.Normalize();
        }

        Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;
        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
                           m_CharacterController.height / 2f, ~0, QueryTriggerInteraction.Ignore);
        desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;
        m_MoveDir.x = desiredMove.x * speed;
        m_MoveDir.z = desiredMove.z * speed;
        //Debug.Log("m_Jump = " + m_Jump);
        //Debug.Log("m_Jumping = " + m_Jumping);
        if (InputManager.GetButtonDown("Jump")) {
            Debug.Log("11111111111111111111111111111111111111111111111111111111111111111111");
        }
        if (!m_Jump && !m_Jumping) {
            m_Jump = InputManager.GetButtonDown("Jump");
        }

        if (m_CharacterController.isGrounded) {
            m_MoveDir.y = -m_StickToGroundForce;

            if (m_Jump) {
                m_MoveDir.y = m_JumpSpeed;
                m_Jump = false;
                m_Jumping = true;
            }
        }
        else {
            m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
        }

        m_CharacterController.Move(m_MoveDir * Time.fixedDeltaTime);
        //UpdateMousePosition();
        m_MouseLook.UpdateCursorLock();
    }
}
