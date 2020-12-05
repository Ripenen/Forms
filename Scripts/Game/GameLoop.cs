using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private GameAsset[] GameAssets = new GameAsset[] { };

    [Header("Speed Parametrs")]
    public float Speed;
    public float StepUpSpeed;
    public float MaxSpeed;

    [Header("UI")]
    public GameObject ContinuePanel;
    public GameObject RetryPanel;

    public Button NoThanks;
    public Button RetryButton;

    public Text YouScore;
    public Text MaxScore;
    public Text CountDownText;

    public Text ContinueScore;

    [Header("Components")]
    public Score Score;
    public SaveLoad SaveLoad;
    public AudioSource Bubbles;

    private BarricadeControl _barricadeControl;

    private int _lastRandom = -1;
    private int _random;
    private int _iter = 5;
    private bool isContinue = false;

    private string _soundEnabled => SaveLoad.LoadVolume();
    private string _vibrationEnabled => SaveLoad.LoadVibration();

    private void Start()
    {
        SpawnGameAsset();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Win()
    {
        if (_soundEnabled == "True")
        {
            Bubbles.Play();
        }

        if (_vibrationEnabled == "True")
        {
            Handheld.Vibrate();
        }

        if (Speed < MaxSpeed)
        {
            Speed += StepUpSpeed;
        }

        Score.AddScore(1);

        if (Score.GetScore() > SaveLoad.LoadScore())
        {
            SaveLoad.SaveScore(Score.GetScore());
        }

        GameAssets[_lastRandom].Despawn();

        SpawnGameAsset();
    }

    public void Lose()
    {
        NoThanks.onClick.RemoveAllListeners();
        RetryButton.onClick.RemoveAllListeners();

        Speed -= Score.GetScore() * StepUpSpeed;

        ContinuePanel.SetActive(false);
        RetryPanel.SetActive(true);
        Score.gameObject.SetActive(false);

        MaxScore.text = "Best\n " + SaveLoad.LoadScore();

        YouScore.text = "Score\n " + Score.GetScore();

        Score.SetScore(0);

        _iter = 5;
        CountDownText.text = _iter.ToString();
    }

    private void SpawnGameAsset()
    {
        _random = Random.Range(0, GameAssets.Length);

        while (_lastRandom == _random)
        {
            _random = Random.Range(0, GameAssets.Length);
        }

        GameAssets[_random].Spawn();

        _barricadeControl = GameAssets[_random].GetBarricadeControl();

        _barricadeControl.GameLoop = gameObject.GetComponent<GameLoop>();

        _lastRandom = _random;

        CancelInvoke();
    }

    public void ReloadScene()
    {
        RetryButton.onClick.RemoveAllListeners();

        GameAssets[_lastRandom].Despawn();

        ContinuePanel.SetActive(false);
        RetryPanel.SetActive(false);
        Score.gameObject.SetActive(true);

        SpawnGameAsset();

        isContinue = false;
    }

    public void ContinueGame()
    {
        RetryButton.onClick.RemoveAllListeners();

        GameAssets[_lastRandom].Despawn();

        ContinuePanel.SetActive(false);
        RetryPanel.SetActive(false);
        Score.gameObject.SetActive(true);

        SpawnGameAsset();

        _iter = 5;
        CountDownText.text = _iter.ToString();

        isContinue = true;
    }

    public void ContinueOrLose()
    {
        if(isContinue == false)
        {
            if (!IsInvoking())
            {
                InvokeRepeating(nameof(CountDown), 1, 1);
            }

            ContinuePanel.SetActive(true);

            ContinueScore.text = "Score\n " + Score.GetScore();

            Score.gameObject.SetActive(false);

            _iter = 5;
            CountDownText.text = _iter.ToString();
        }
        else if (isContinue)
        {
            InvokeRepeating(nameof(CountDown), 0, 1);
            _iter = 0;
        }
    }

    private void CountDown()
    {
        CountDownText.text = (_iter - 1).ToString();
        _iter -= 1;

        if (_iter == -1)
        {
            Lose();

            CancelInvoke();

            _iter = 5;
            CountDownText.text = _iter.ToString();
        }
    }

}
