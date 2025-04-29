using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public void GoToGame() {
        SceneManager.LoadScene("Gameplay");
    }

    public void Restart() {
        SceneManager.LoadScene("Gameplay");
    }
}
