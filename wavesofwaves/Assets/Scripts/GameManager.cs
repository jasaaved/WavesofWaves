using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public enum StateType
    {
        DEFAULT,      //Fall-back state, should never happen
        PLAYING,      //waiting for other player to finish his turn
        SHOP,    //Once, on start of each player's turn
        GAMEOVER,
    };
    // Testing
    public bool isUsingMouse;
    public bool enemiesDisabled;
    public bool musicDisabled;

    // Game state
    public StateType currentState;
    public bool isGameOver;

    // Level
    public int score;
    public int currentLevel;

    // Components
    public Transform player;
    public List<EnemyHealth> enemies = new List<EnemyHealth>();

    // UI
    public GameObject gameoverMenu;
    public GameObject HUDMenu;
    public Text scoreText;
    public Text hiScore;
    public Text displayText;
    public Canvas canvas;

    // Audio 
    public AudioSource sfxSource;
    public AudioClip levelUpSound;
    public AudioClip beep;


    public void Start()
    {
        currentState = StateType.PLAYING;
        isGameOver = false;
        DisplayText("Start!");
    }

    public void Update()
    {
        if (isGameOver)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameoverMenu.SetActive(true);
        HUDMenu.SetActive(false);
    }

    public void PlayClip(AudioClip clip, float volume, bool isLooping)
    {
        sfxSource.clip = clip;
        sfxSource.volume = volume;
        sfxSource.loop = isLooping;
        sfxSource.Play();
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void CheckEnemies()
    {
        Debug.Log(enemies.Count);
        if (enemies.Count == 1)
        {
            LevelCompleted();
        }
    }

    public void LevelCompleted()
    {
        DisplayText("Level Completed! Get ready for the next wave!", 14);
        StartCoroutine("StartCountdown");
    }

    public IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(5);
        IncrementLevel();
    }
 
    public void IncrementLevel()
    {
        currentLevel++;
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
        DisplayText("GO!");

        foreach (EnemySpawner spawner in spawners)
        {
            spawner.ResetSpawnCount();
        }
    }

    public void DisplayText(string text)
    {
        Text tempTextBox = Instantiate(displayText, new Vector3(0, 15, 0), transform.rotation) as Text;
        tempTextBox.transform.SetParent(canvas.transform, false);
        tempTextBox.text = text;
        //tempTextBox.CrossFadeAlpha(0f, 2.5f, true);
        Destroy(tempTextBox, 5f);
    }

    public void DisplayText(string text, int size)
    {
        Text tempTextBox = Instantiate(displayText, new Vector3(0, 15, 0), transform.rotation) as Text;
        tempTextBox.transform.SetParent(canvas.transform, false);
        tempTextBox.fontSize = size;
        tempTextBox.text = text;
        //tempTextBox.CrossFadeAlpha(0f, 2.5f, true);
        Destroy(tempTextBox, 2.5f);
    }

    public void DisplayText(string text, Color color)
    {
        Text tempTextBox = Instantiate(displayText, new Vector3(53, 9.5f, 0), transform.rotation) as Text;
        tempTextBox.transform.SetParent(canvas.transform, false);
        tempTextBox.text = text;
        tempTextBox.color = color;
        //tempTextBox.CrossFadeAlpha(0f, 5f, true);
        Destroy(tempTextBox, 2.5f);
    }
}