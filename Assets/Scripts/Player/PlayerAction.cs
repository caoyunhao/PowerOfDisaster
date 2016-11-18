using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {

    public float m_Range;
    public float m_PullForceSize;
    public float m_PushForceSize;
    public GameObject m_PlayerEyes;     //摄像机

    private Rigidbody m_DragBody;
    private bool m_HasBullet;
    private bool m_HasShoot;
    private GameObject m_Bullet;        //手中的石头
    private GameObject m_AimObject;     //正在拉的石头
    

    // Use this for initialization
    void Start() {
        m_Range = 100.0f;
        m_PullForceSize = 100.0f;       //拉力
        m_PushForceSize = 100.0f;       //推力
        m_HasShoot = true;              //是否已射击，默认已射击（此时可抓取石头）
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (m_DragBody != null) {
            m_DragBody.constraints = (UnityEngine.RigidbodyConstraints)0;
            m_DragBody = null;
        }

        CheckMouseLeft();
        CheckMouseRight();
        CheckFirstSkill();
        CheckSecondSkill();
        CheckThirdSkill();
    }

    void CheckMouseLeft() {
        if (InputManager.GetMouseButton("left")) {
            //Debug.Log("click left button !");
            if (!m_HasBullet) {
                TakeStone();
            }
        }
        else {
            m_AimObject = null;
        }
    }

    void CheckMouseRight() {
        if (InputManager.GetMouseButton("right")) {
            //Debug.Log("click");
            if (m_HasBullet) {
                Shoot();
            }
        }
    }

    void CheckFirstSkill() {
        if (InputManager.GetKey("firstskill")) {
            Debug.Log("firstskill");
            FirstSkill();
        }
    }

    void CheckSecondSkill() {
        if (InputManager.GetKey("secondskill")) {
            Debug.Log("secondskill");
            SecondSkill();
        }
    }

    void CheckThirdSkill() {
        if (InputManager.GetKey("thirdskill")) {
            Debug.Log("thirdskill");
            ThirdSkill();
        }
    }

    void TakeStone() {
        Ray takeRay = new Ray();
        RaycastHit takeHit;
        int shootableMask = LayerMask.GetMask("Stone");
        takeRay.origin = m_PlayerEyes.transform.position;
        takeRay.direction = m_PlayerEyes.transform.forward;

        //Debug.Log("a takeRay");
        if (Physics.Raycast(takeRay, out takeHit, m_Range, shootableMask)) {

            m_AimObject = takeHit.collider.gameObject;
            Vector3 forcePoint = takeHit.point;
            Vector3 forceDir = transform.position - forcePoint;
            forceDir.Normalize();

            //标记目标物体被拉动
            //if (m_AimObject.GetComponent<OnMove>() != null)
            //    m_AimObject.GetComponent<OnMove>().isDragged = true;

            Rigidbody aimBody = m_AimObject.GetComponent<Rigidbody>();
            aimBody.constraints = (UnityEngine.RigidbodyConstraints)80;

            aimBody.AddForceAtPosition(forceDir * m_PullForceSize, forcePoint, ForceMode.Force);
            m_DragBody = aimBody;
        }
    }

    void LoadBullet(Collider other)
    {
        if (other.gameObject == m_AimObject && m_HasShoot)
        {
            m_HasShoot = false;
            m_Bullet = m_AimObject;
            m_HasBullet = true;
            m_Bullet.GetComponent<BoxCollider>().isTrigger = true;
            m_Bullet.GetComponent<Rigidbody>().useGravity = false;
            m_Bullet.SetActive(false);
        }
    }

    void Shoot() {
        m_HasBullet = false;
        m_Bullet.transform.position = m_PlayerEyes.transform.position;
        //m_Bullet.transform.rotation = m_PlayerEyes.transform.rotation;
        m_Bullet.transform.rotation= Quaternion.Euler(0, 0, 0);
        Rigidbody bulletBody = m_Bullet.GetComponent<Rigidbody>();
        m_Bullet.SetActive(true);
        bulletBody.velocity = m_PlayerEyes.transform.forward * m_PushForceSize / bulletBody.mass;
        //m_Bullet.GetComponent<Rigidbody>().AddForce(m_PlayerEyes.transform.forward * m_PushForceSize, ForceMode.Impulse);
        //Debug.Log("ForceMode.Impulse作用方式下C每帧增加的速度：" + m_Bullet.GetComponent<Rigidbody>().velocity.magnitude);
    }

    void FirstSkill() {

    }

    void SecondSkill() {

    }

    void ThirdSkill() {

    }

    void OnTriggerEnter(Collider other) {
        LoadBullet(other);
    }

    void OnTriggerStay(Collider other) {
        LoadBullet(other);
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject == m_Bullet && !m_HasShoot) {
            m_HasShoot = true;
            m_HasBullet = false;
            m_Bullet.GetComponent<BoxCollider>().isTrigger = false;
            m_Bullet.GetComponent<Rigidbody>().useGravity = true;
            m_Bullet.SetActive(true);
            m_Bullet = null;
            m_AimObject = null;
        }
    }
}
