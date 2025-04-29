using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public void GoToGame() {
        SceneManager.LoadScene("Gameplay");
    }

    public void Restart() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>().Reset();
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<HealthManager>().Reset();
    }
}
