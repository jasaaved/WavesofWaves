using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour {

    public void RetryGame()
    {
        GameManager.scoreInt = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TitleScreen()
    {
        GameManager.scoreInt = 0;
        SceneManager.LoadScene(0);
    }
}
