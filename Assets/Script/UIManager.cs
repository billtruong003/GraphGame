using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI X_Value;
    public TextMeshProUGUI Y_Value;
    [SerializeField] private Transform popUpContainer;
    [SerializeField] private GameObject popUpText;
    private void Awake()
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }
    public void SetValueTarget(int x, int y)
    {
        X_Value.text = $"x: {x}";
        Y_Value.text = $"y: {y}";
    }
    public void PopUpTxt(int correct = 0)
    {
        if (correct == 0)
        {
            Debug.Log("Correct");
            GameObject Popup = Instantiate(popUpText, popUpContainer);
            PopupController popUpController = Popup.GetComponent<PopupController>();
            popUpController.PopUpCorrect(MainManager.Instance.getScore);
        }
        else
        {
            GameObject Popup = Instantiate(popUpText, popUpContainer);
            PopupController popUpController = Popup.GetComponent<PopupController>();
            popUpController.PopUpFalse();
        }
    }
}
