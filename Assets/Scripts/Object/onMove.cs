//using UnityEngine;
//using System.Collections;

//public class OnMove : MonoBehaviour {

//    public float onDraggedSpeed;//判定是否处于被拉动状态的速度
//    public bool isDragged;//是否处于被拉动状态
//    public bool becomeBullet;//是否成为子弹
//    public GameObject player;
//    public PlayerAction player_action;

//    // Use this for initialization
//    void Start () {
//        isDragged = false;
//        onDraggedSpeed = 2.0f;
//        becomeBullet = false;
//        player = GameObject.FindGameObjectWithTag("Player");
//        player_action = player.transform.FindChild("Main Camera").gameObject.GetComponent<PlayerAction>();
//        Debug.Log(this.gameObject);
//    }
	
//	// Update is called once per frame
//	void Update () {
//        if (player_action.m_DragBody!=this.GetComponent<Rigidbody>()&& this.GetComponent<Rigidbody>().velocity.magnitude < onDraggedSpeed)
//            isDragged = false;

//        if(becomeBullet)
//        {
//            Debug.Log("jin le");
//            this.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(0, 3, 3f), 0.2f);
//            if (this.transform.localPosition==new Vector3(0, 3, 3f))
//            { 
//                this.gameObject.GetComponent<OnMove>().enabled = false;
//            }
//        }
//	}

//    void FixedUpdate()
//    {

//    }

//    //判断是否成为子弹，必须满足被拽动（即isDragged为1）并碰撞到player
//    public void WillBecomeBullet(UnityEngine.Collision collision)
//    {
//        if (isDragged)
//        {
//            if (collision.gameObject.tag == "Player")
//            {

//                GameObject player_action = collision.gameObject.transform.FindChild("Main Camera").gameObject;
//                if (player_action.GetComponent<PlayerAction>() != null && player_action.GetComponent<PlayerAction>().m_HasBullet == false)
//                {
//                    becomeBullet = true;
//                    player_action.GetComponent<PlayerAction>().m_Bullet = this.gameObject;
//                    transform.parent = collision.gameObject.transform;
//                    this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
//                    player_action.GetComponent<PlayerAction>().m_HasBullet = true;
//                }
//            }

//        }
//    }

//    public void OnCollisionEnter(UnityEngine.Collision collision)
//    {
//        WillBecomeBullet(collision);
//    }

//    public void OnCollisionStay(UnityEngine.Collision collision)
//    {
//        WillBecomeBullet(collision);
//    }
//}
