using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPManager : MonoBehaviour {

    public static float heartNumber;
    public GameObject player;
    Text text;

	void Start () {
        text = GetComponent<Text>();
        heartNumber = player.GetComponent<PlayerHealth>().startingHealth;
	}
	
	void FixedUpdate () {
        heartNumber = player.GetComponent<PlayerHealth>().currentHealth;
        if (heartNumber < 0)
            heartNumber = 0;
        text.text = " " + heartNumber;
    }
}
