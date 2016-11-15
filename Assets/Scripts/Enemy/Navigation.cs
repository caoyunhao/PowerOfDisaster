using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {
    private NavMeshAgent Enemy;
    public Transform target;

	// Use this for initialization
	void Start () {
        Enemy=gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        Enemy.SetDestination(target.position);
	}
}
