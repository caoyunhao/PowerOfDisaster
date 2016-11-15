using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
    public GameObject player;
    public PlayerAction player_action;
    // Use this for initialization
    void Start () {
        player = transform.FindChild("Main Camera").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
