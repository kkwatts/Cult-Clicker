using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class HealthManager : MonoBehaviour {
    public float maxHealth;
    public float health;
    public float attackDamage;
    public Slider healthBar;
    public GameObject winText;
    public GameObject loseText;
    public GameObject roundText;

    private float attackTimer;
    private float attackTimerThreshold;
    private int level;
    private bool switching;
    private GameObject enemy;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        health = maxHealth;
        attackTimerThreshold = 2f;
        attackTimer = attackTimerThreshold;
        attackDamage = 1f;
        level = 1;
        switching = false;

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
        if (gameObject.CompareTag("Player")) {
            roundText.GetComponent<TextMeshProUGUI>().SetText("Round " + level);
        }

        attackTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && gameObject.CompareTag("Enemy") && player.GetComponent<HealthManager>().health > 0f) {
            health -= attackDamage;
        }
        else if (attackTimer < 0f && gameObject.CompareTag("Player") && enemy.GetComponent<HealthManager>().health > 0f) {
            health--;
            attackTimer = attackTimerThreshold;
        }
        else if (gameObject.CompareTag("Player") && enemy.GetComponent<HealthManager>().health <= 0f && health > 0f) {
            winText.SetActive(true);
            if (!switching) {
                StartCoroutine(Wait(2f));
                switching = true;
            }
        }
        else if (gameObject.CompareTag("Player") && health <= 0f) {
            loseText.SetActive(true);
        }
    }

    public void Reset() {
        health = maxHealth;
        attackTimer = attackTimerThreshold;
        if (gameObject.CompareTag("Player")) {
            winText.SetActive(false);
            loseText.SetActive(false);
        }
    }

    public IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds);
        Reset();
        enemy.GetComponent<HealthManager>().Reset();
        enemy.GetComponent<HealthManager>().attackDamage += 0.5f;
        level++;
        switching = false;
    }
}
