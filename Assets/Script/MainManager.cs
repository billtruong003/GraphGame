using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    [SerializeField] private Transform pickedPoint;
    [SerializeField] private int xValue;
    [SerializeField] private int yValue;

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
        Debug.Log($"{xValue} | {yValue}");
    }
    public void SetPoint(Transform point)
    {
        if (pickedPoint != null)
        {
            pickedPoint.GetComponent<CheckAnswer>().UnPick();
        }
        pickedPoint = point;
    }
    public void CheckAnswer()
    {
        if (pickedPoint == null)
            return;

        if (pickedPoint.name == $"{xValue} | {yValue}")
        {
            pickedPoint.GetComponent<CheckAnswer>().AnswerDecide(true);
            return;
        }
        pickedPoint.GetComponent<CheckAnswer>().AnswerDecide(false);
    }
}
