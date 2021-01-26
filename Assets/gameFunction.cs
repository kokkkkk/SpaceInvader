using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameFunction : MonoBehaviour {
    public GameObject RestartButton;
    public GameObject QuitButton;
    public GameObject GameTitle;
    public GameObject GameOverTitle;
    public GameObject PlayButton;
    public GameObject boss;
    public GameObject background;
    public bool IsPlaying = false;
    public bool bosss;
    public Text ScoreText;
    public Text timeText;
    public int score = 0;
    public static gameFunction Instance;
    public GameObject Enemy;
    public GameObject enemy2;
    public float time;
    public float times;
    public float countime;
    bool goboss;
    bool created;
    // Use this for initialization
    void Start() {
        countime = 3;
        created = false;
        boss.SetActive(true);
        Instance = this;
        GameOverTitle.SetActive(false);
        RestartButton.SetActive(false);
    }
    public void GameStart()
    {
        goboss = false;
        bosss = false;
        QuitButton.SetActive(false);
        IsPlaying = true;
        GameTitle.SetActive(false);
        PlayButton.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        times += Time.deltaTime;
        Vector3 pos = new Vector3(Random.Range(-2.5f, 2.5f), 4.5f, 0);
        Vector3 pos2 = new Vector3(Random.Range(-2.5f, 2.5f), 4.5f, 0);
        if (pos == pos2)
        {
            pos2 = new Vector3(Random.Range(-2.5f, 2.5f), 4.5f, 0);
        }
        if (IsPlaying == true || countime > 0 && goboss == true)
        {
            counttime();
        }
        if (time > 0.5f && IsPlaying == true)
        {
            Instantiate(Enemy, pos, transform.rotation);
            time = 0f;
        }
        if (times > 3f && IsPlaying == true)
        {
            Instantiate(enemy2, pos2, transform.rotation);
            times = 0f;
        }
        if (countime <= 0 && IsPlaying==true || countime <= 0 && goboss == true)
        {
            GameOver();
        }
        if (countime >= 50 && bosss == false&&created==false)
        {
            Vector3 pos3 = new Vector3(0, 3f, 0);
            Instantiate(boss, pos3, transform.rotation);
            created = true;
            goboss = true;
        }
        if (goboss == true)
        {
            IsPlaying = false;
            boss.SetActive(true);
        }
     }
    void counttime()
    {
        countime -= Time.deltaTime;
        timeText.text = "Time: " + (int)countime;
    }
    public void bossWin()
    {
        goboss = false;
        boss.SetActive(false);
        bosss = true;
        IsPlaying = true;
    }
    public void AddScore(int scorePlus)
    {
        score += scorePlus;
        ScoreText.text = "Score: " + score;
    }
    public void addtime(int time)
    {
        countime += (time);
        timeText.text = "Time: " + (int)countime;
    }
    public void GameOver()
    {
        RestartButton.SetActive(true);
        QuitButton.SetActive(true);
        IsPlaying = false;
        GameOverTitle.SetActive(true);
    }
    public void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
