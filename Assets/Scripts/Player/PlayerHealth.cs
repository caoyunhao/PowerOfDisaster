using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float startingHealth = 100.0f;
    public float currentHealth;

    public Slider healthSlider;

    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        healthSlider.value = currentHealth;
	}
}
