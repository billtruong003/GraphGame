using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CheckAnswer : MonoBehaviour
{
    [SerializeField] private Image CorrectCheck;
    [SerializeField] private Color correctCol;
    [SerializeField] private Color falseCol;
    [SerializeField] private Color pickCol;

    public void UnPick()
    {
        CorrectCheck.gameObject.SetActive(false);
    }
    public void PickAns()
    {
        MainManager.Instance.SetPoint(transform);
        ChangeColPick();
    }
    public void ChangeColPick()
    {
        CorrectCheck.color = pickCol;
        CorrectCheck.gameObject.SetActive(true);
    }
    public void AnswerDecide(bool status)
    {
        if (status)
        {
            CorrectCheck.color = correctCol;
            return;
        }
        CorrectCheck.color = falseCol;
    }

}
