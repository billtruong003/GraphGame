using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;

public class AssignPoint : MonoBehaviour
{
    [SerializeField] private Transform pointPP;
    [SerializeField] private Transform pointNN;
    [SerializeField] private Transform pointPN;
    [SerializeField] private Transform pointNP;
    [SerializeField] private GameObject prefabPoint;
    [SerializeField] private Transform pointZero;
    [SerializeField] private List<Transform> positiveX;
    [SerializeField] private List<Transform> negativeX;
    [SerializeField] private List<Transform> positiveY;
    [SerializeField] private List<Transform> negativeY;
    [SerializeField] private List<Transform> pointInit;

    [Button]
    public void SetUpPoints()
    {
        SpawnZeroPoint();
        foreach (Transform pointX in positiveX)
        {
            Transform point = Instantiate(prefabPoint, pointPP).transform;
            TextMeshProUGUI TextX = pointX.GetComponentInChildren<TextMeshProUGUI>();
            string X_Value = TextX.text;
            string Y_Value = "0";
            point.name = $"{X_Value} | {Y_Value}";
            Vector3 newPos = new Vector3(pointX.position.x, pointX.position.y);
            point.SetPositionAndRotation(newPos, Quaternion.identity);
            pointInit.Add(point);
        }
        foreach (Transform pointX in negativeX)
        {
            Transform point = Instantiate(prefabPoint, pointPP).transform;
            TextMeshProUGUI TextX = pointX.GetComponentInChildren<TextMeshProUGUI>();
            string X_Value = TextX.text;
            string Y_Value = "0";
            point.name = $"{X_Value} | {Y_Value}";
            Vector3 newPos = new Vector3(pointX.position.x, pointX.position.y);
            point.SetPositionAndRotation(newPos, Quaternion.identity);
            pointInit.Add(point);
        }
        foreach (Transform pointX in positiveY)
        {
            Transform point = Instantiate(prefabPoint, pointPP).transform;
            TextMeshProUGUI TextX = pointX.GetComponentInChildren<TextMeshProUGUI>();
            string X_Value = "0";
            string Y_Value = TextX.text;
            point.name = $"{X_Value} | {Y_Value}";
            Vector3 newPos = new Vector3(pointX.position.x, pointX.position.y);
            point.SetPositionAndRotation(newPos, Quaternion.identity);
            pointInit.Add(point);
        }
        foreach (Transform pointX in negativeY)
        {
            Transform point = Instantiate(prefabPoint, pointPP).transform;
            TextMeshProUGUI TextX = pointX.GetComponentInChildren<TextMeshProUGUI>();
            string X_Value = "0";
            string Y_Value = TextX.text;
            point.name = $"{X_Value} | {Y_Value}";
            Vector3 newPos = new Vector3(pointX.position.x, pointX.position.y);
            point.SetPositionAndRotation(newPos, Quaternion.identity);
            pointInit.Add(point);
        }
        foreach (Transform pointX in positiveX)
        {
            foreach (Transform pointY in positiveY)
            {
                Transform point = Instantiate(prefabPoint, pointPP).transform;
                TextMeshProUGUI TextX = pointX.GetComponentInChildren<TextMeshProUGUI>();
                string X_Value = TextX.text;
                TextMeshProUGUI TextY = pointY.GetComponentInChildren<TextMeshProUGUI>();
                string Y_Value = TextY.text;
                point.name = $"{X_Value} | {Y_Value}";
                Vector3 newPos = new Vector3(pointX.position.x, pointY.position.y);
                point.SetPositionAndRotation(newPos, Quaternion.identity);
                pointInit.Add(point);
            }
        }
        foreach (Transform pointX in negativeX)
        {
            foreach (Transform pointY in negativeY)
            {
                Transform point = Instantiate(prefabPoint, pointNN).transform;
                TextMeshProUGUI TextX = pointX.GetComponentInChildren<TextMeshProUGUI>();
                string X_Value = TextX.text;
                TextMeshProUGUI TextY = pointY.GetComponentInChildren<TextMeshProUGUI>();
                string Y_Value = TextY.text;
                point.name = $"{X_Value} | {Y_Value}";
                Vector3 newPos = new Vector3(pointX.position.x, pointY.position.y);
                point.SetPositionAndRotation(newPos, Quaternion.identity);
                pointInit.Add(point);
            }
        }
        foreach (Transform pointX in positiveX)
        {
            foreach (Transform pointY in negativeY)
            {
                Transform point = Instantiate(prefabPoint, pointPN).transform;
                TextMeshProUGUI TextX = pointX.GetComponentInChildren<TextMeshProUGUI>();
                string X_Value = TextX.text;
                TextMeshProUGUI TextY = pointY.GetComponentInChildren<TextMeshProUGUI>();
                string Y_Value = TextY.text;
                point.name = $"{X_Value} | {Y_Value}";
                Vector3 newPos = new Vector3(pointX.position.x, pointY.position.y);
                point.SetPositionAndRotation(newPos, Quaternion.identity);
                pointInit.Add(point);
            }
        }
        foreach (Transform pointX in negativeX)
        {
            foreach (Transform pointY in positiveY)
            {
                Transform point = Instantiate(prefabPoint, pointNP).transform;
                TextMeshProUGUI TextX = pointX.GetComponentInChildren<TextMeshProUGUI>();
                string X_Value = TextX.text;
                TextMeshProUGUI TextY = pointY.GetComponentInChildren<TextMeshProUGUI>();
                string Y_Value = TextY.text;
                point.name = $"{X_Value} | {Y_Value}";
                Vector3 newPos = new Vector3(pointX.position.x, pointY.position.y);
                point.SetPositionAndRotation(newPos, Quaternion.identity);
                pointInit.Add(point);
            }
        }
    }
    private void SpawnZeroPoint()
    {
        Transform point = Instantiate(prefabPoint, pointZero).transform;
        string X_Value = "0";
        string Y_Value = "0";
        point.name = $"{X_Value} | {Y_Value}";
        Vector3 newPos = new Vector3(0, 75);
        point.SetLocalPositionAndRotation(newPos, Quaternion.identity);
        pointInit.Add(point);
    }
    [Button]
    public void ClearPoints()
    {
        foreach (Transform point in pointInit)
        {
            DestroyImmediate(point.gameObject);
        }
        pointInit.Clear();
    }
}
