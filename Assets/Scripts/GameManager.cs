using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject dayPanel;
    public int day { get; private set; }

    private void Start()
    {
        day = 0;
        StartDayTransition();
    }

    public void StartDayTransition()
    {
        dayPanel.GetComponentInChildren<TextMeshProUGUI>().text = "DAY " + day;
        dayPanel.SetActive(true);
        Invoke("EndDayTransition", 3);
    }

    public void EndDayTransition()
    {
        dayPanel.SetActive(false);
    }

}
