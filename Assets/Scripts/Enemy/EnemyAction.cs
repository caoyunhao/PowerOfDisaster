using UnityEngine;
using System.Collections;

public class EnemyAction : MonoBehaviour {
    static int I_AM_WALKING = 1;
    static int I_AM_ATTACKING = 2;
    static int I_CANNOT_MOVE = 0;

    Transform m_transform;
    GameObject player;
    NavMeshAgent m_agent;
    Vector3 m_destination;//当前目标
    public float m_speed = 0.1f;//移动速度

    public float m_attackarea;//攻击范围
    public float m_attackangle;//攻击角度
    public float m_attacktime;//攻击间隔

    private int m_state;//当前状态
    private float actionInterval;

    // Use this for initialization
    void Start () {
        m_attacktime = 1f;
        m_state = I_AM_WALKING;
        m_attackarea = 5f;
        m_attackangle = 60f;
        m_transform = this.transform;
        player = GameObject.FindGameObjectWithTag("Player");
        m_agent = GetComponent<NavMeshAgent>();
        m_destination = player.transform.position;
        m_agent.SetDestination(m_destination);
        m_agent.speed = m_speed;

        actionInterval = 0f;
    }
	
    //public void MoveToDestination()
    //{
    //    float speed = m_speed * Time.deltaTime;
    //    m_agent.Move(m_transform.TransformDirection(new Vector3(0, 0, speed)));
    //}

    public void UpdateDestination()
    {
        m_destination = player.transform.position;
        m_agent.SetDestination(m_destination);
    }
    
    public void SetNewDestination()//如果player距离和当前目标点距离大于攻击范围，更换目标
    {
        if(Vector3.Distance(m_destination,player.transform.position)>m_attackarea)
        {
            UpdateDestination();
        }
    }

    public void Attack()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);//距离
        Vector3 norVec = transform.rotation * Vector3.forward * 5;//此处*5只是为了画线更清楚,可以不要
        Vector3 temVec = player.transform.position - transform.position;
        Debug.DrawLine(transform.position, norVec, Color.red);//画出技能释放者面对的方向向量
        Debug.DrawLine(transform.position, player.transform.position, Color.green);//画出技能释放者与目标点的连线
        float angle = Mathf.Acos(Vector3.Dot(norVec.normalized, temVec.normalized)) * Mathf.Rad2Deg;//计算两个向量间的夹角
        if (distance < 0.5*m_attackarea)
        {
            if (angle <= m_attackangle * 0.5f)
            {
                Debug.Log("在扇形范围内");
                m_state = I_AM_ATTACKING;
                m_agent.Stop();
                actionInterval = m_attacktime;
            }
            else
            {
                m_state = I_AM_WALKING;
                UpdateDestination();
            }
        }
    }


	// Update is called once per frame
	void Update () {
       
        
    }

    void FixedUpdate()
    {
        if (actionInterval > 0)
        {
            actionInterval -= Time.fixedDeltaTime;
        }
        else
        {
            m_agent.Resume();
            actionInterval = 0;
            SetNewDestination();
            Attack();
        }
    }

    void OnCollisonEnter(UnityEngine.Collision collision)
    {

    }
}
