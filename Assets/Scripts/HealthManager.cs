using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    public float maxHealth;
    public float health;
    public Slider healthBar;
    public GameObject winText;
    public GameObject loseText;

    private float attackTimer;
    private float attackTimerThreshold;
    private GameObject enemy;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        health = maxHealth;
        attackTimerThreshold = 2f;
        attackTimer = attackTimerThreshold;

        if (gameObject.CompareTag("Player")) {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
        else if (gameObject.CompareTag("Enemy")) {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update() {
        healthBar.value = health / maxHealth;

        attackTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && gameObject.CompareTag("Enemy") && player.GetComponent<HealthManager>().health > 0f) {
            health--;
        }
        else if (attackTimer < 0f && gameObject.CompareTag("Player") && enemy.GetComponent<HealthManager>().health > 0f) {
            health--;
            attackTimer = attackTimerThreshold;
        }
        else if (gameObject.CompareTag("Player") && enemy.GetComponent<HealthManager>().health <= 0f && health > 0f) {
            winText.SetActive(true);
        }
        else if (gameObject.CompareTag("Player") && health <= 0f) {
            loseText.SetActive(true);
        }
    }
}
