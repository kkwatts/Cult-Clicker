using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    public float maxHealth;
    public Slider healthBar;

    private float health;
    private float attackTimer;
    private float attackTimerThreshold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        health = maxHealth;
        attackTimerThreshold = 2f;
        attackTimer = attackTimerThreshold;
    }

    // Update is called once per frame
    void Update() {
        healthBar.value = health / maxHealth;

        attackTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && gameObject.CompareTag("Enemy")) {
            health--;
        }
        else if (attackTimer < 0f && gameObject.CompareTag("Player")) {
            health--;
            attackTimer = attackTimerThreshold;
        }
    }
}
