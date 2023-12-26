using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    [SerializeField] private Transform pickedPoint;
    [SerializeField] private int score;
    [SerializeField] private int xValue;
    [SerializeField] private int yValue;
    bool finish = false;
    public int getScore => score;

    private void Awake()
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }
    private void Start()
    {
        InitValue();
    }
    private void InitValue()
    {
        xValue = Random.Range(-3, 4);
        yValue = Random.Range(-6, 7);
        UIManager.Instance.SetValueTarget(xValue, yValue);
        if (pickedPoint != null)
        {
            pickedPoint.GetComponent<CheckAnswer>().UnPick();
            pickedPoint = null;
        }
        Debug.Log($"{xValue} | {yValue}");
    }
    public void SetPoint(Transform point)
    {
        if (finish)
            return;

        if (pickedPoint != null)
        {
            pickedPoint.GetComponent<CheckAnswer>().UnPick();
        }
        pickedPoint = point;
    }
    public void CheckAnswer()
    {
        if (pickedPoint == null || finish)
            return;

        if (pickedPoint.name == $"{xValue} | {yValue}")
        {
            pickedPoint.GetComponent<CheckAnswer>().AnswerDecide(true);
            score++;
            UIManager.Instance.PopUpTxt();

        }
        else
        {
            pickedPoint.GetComponent<CheckAnswer>().AnswerDecide(false);
            UIManager.Instance.PopUpTxt(1);
        }
        StartCoroutine(Cor_Reset());
    }
    public IEnumerator Cor_Reset()
    {
        yield return new WaitForSeconds(2);
        InitValue();
    }
}
