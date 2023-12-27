using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using PrimeTween;
using TMPro;
using System.Runtime.CompilerServices;
public class MainManager : MonoBehaviour
{
    // Singleton instance of MainManager
    public static MainManager Instance;

    // Serialized fields visible in the Unity Editor
    [SerializeField] private TextMeshProUGUI scoreTMP;
    [SerializeField] private Transform pickedPoint; // The currently selected point
    [SerializeField] private RectTransform player;
    [SerializeField] private int score; // Player's score
    [SerializeField] private int round;
    [SerializeField] private int xValue; // X coordinate for the target point
    [SerializeField] private int yValue; // Y coordinate for the target point


    [SerializeField] private RectTransform scorePanel;
    [SerializeField] private Image badged;
    [SerializeField] private Sprite bronzeBadged;
    [SerializeField] private Sprite silverBadged;
    [SerializeField] private Sprite goldBadged;
    [SerializeField] private TextMeshProUGUI scoreInPanel;

    [SerializeField] private AudioClip Right;
    [SerializeField] private AudioClip Wrong;
    [SerializeField] private AudioClip Fly;
    [SerializeField] private AudioSource soundSource;
    bool finish = false; // Flag indicating if the game has finished

    // Property to get the current score
    public int getScore => score;

    // Set up the singleton instance on Awake
    private void Awake()
    {
        Instance = this;
    }

    // Clean up the singleton instance on OnDestroy
    private void OnDestroy()
    {
        Instance = null;
    }

    // Initialization on Start
    private void Start()
    {
        Tween.Scale(player, 1, 2, Ease.OutElastic);
        UpdateScore();
        InitValue(); // Initialize values for the game
    }
    private void UpdateScore()
    {
        scoreTMP.text = score.ToString();
    }
    // Initialize target values for the game
    private void InitValue()
    {
        xValue = Random.Range(-3, 4); // Random X coordinate between -3 and 3
        yValue = Random.Range(-6, 7); // Random Y coordinate between -6 and 6
        if (xValue == 0 && yValue == 0)
        {
            int randNum = Random.Range(0, 2);
            if (randNum == 0)
            {
                xValue = Random.Range(1, 4);
            }
            else
            {
                yValue = Random.Range(1, 6);
            }
        }
        UIManager.Instance.SetValueTarget(xValue, yValue); // Update UI with target values
        if (pickedPoint != null)
        {
            pickedPoint.GetComponent<CheckAnswer>().UnPick(); // Unselect the previously picked point
            pickedPoint = null;

        }
        Debug.Log($"{xValue} | {yValue}"); // Log the target coordinates
    }

    // Set the currently picked point
    public void SetPoint(Transform point)
    {
        if (finish)
            return;

        if (pickedPoint != null)
        {
            pickedPoint.GetComponent<CheckAnswer>().UnPick(); // Unselect the previously picked point
        }
        pickedPoint = point; // Set the newly picked point
    }

    // Check the selected point against the target and update score
    public void CheckAnswer()
    {
        if (pickedPoint == null || finish)
            return;

        if (pickedPoint.name == $"{xValue} | {yValue}")
        {
            pickedPoint.GetComponent<CheckAnswer>().AnswerDecide(true); // Correct answer
            score += 10;
            UpdateScore();
            UIManager.Instance.PopUpTxt(); // Display correct answer UI
            soundSource.PlayOneShot(Right);
        }
        else
        {
            pickedPoint.GetComponent<CheckAnswer>().AnswerDecide(false); // Incorrect answer
            UIManager.Instance.PopUpTxt(1); // Display incorrect answer UI
            soundSource.PlayOneShot(Wrong);
        }
        round++;
        if (round > 10)
        {
            AppearMenu();
        }
        soundSource.PlayOneShot(Fly);
        Tween.Position(player, endValue: pickedPoint.position, duration: 1.5f);
        StartCoroutine(Cor_Reset()); // Reset the game after a delay
    }
    public void AppearMenu()
    {
        scorePanel.gameObject.SetActive(true);
        Tween.Scale(scorePanel, 1, 2, Ease.InElastic);
        scoreInPanel.text = $"Score: {score}";
        finish = true;
        if (score < 50)
        {
            badged.sprite = bronzeBadged;
        }
        else if (score < 80)
        {
            badged.sprite = silverBadged;
        }
        else
        {
            badged.sprite = goldBadged;
        }
    }
    // Coroutine to reset the game after a delay
    public IEnumerator Cor_Reset()
    {
        yield return new WaitForSeconds(2);
        InitValue(); // Reset the game values
    }
}
