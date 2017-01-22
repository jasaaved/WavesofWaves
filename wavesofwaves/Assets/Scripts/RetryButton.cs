using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour {

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
