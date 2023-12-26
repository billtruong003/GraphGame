using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP;

    private void Start()
    {
        StartCoroutine(KillPopUp());
    }
    public IEnumerator KillPopUp()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
    public void PopUpFalse()
    {
        TMP.text = "Try Again!";
    }
    public void PopUpCorrect(int numStreak)
    {
        if (numStreak == 1)
        {
            TMP.text = "Correct!";
            return;
        }
        if (numStreak == 2)
        {
            TMP.text = "Excellent!";
            return;
        }
        if (numStreak % 10 == 0)
        {
            TMP.text = "Perfection!";
            return;
        }
        TMP.text = $"On Streak {numStreak.ToString()}!";
    }
    public void PopUpNotice()
    {
        TMP.text = "Please Choose The Correct Point!";
    }
}
