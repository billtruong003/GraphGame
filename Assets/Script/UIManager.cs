using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI X_Value;
    public TextMeshProUGUI Y_Value;
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
}
