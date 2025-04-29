using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    public float maxHealth;
    public Slider healthBar;

    private float health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        healthBar.value = health / maxHealth;
    }
}
