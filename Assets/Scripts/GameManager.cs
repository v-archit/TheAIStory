using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject dayPanel;
    public GameObject dialoguePanel;
    public GameObject introGamePanel;
    public StoryElement[] aiStoryElements;
    public int day { get; private set; }

	private static GameManager instance;

	private void Awake()
	{
		if (instance != null)
			Debug.Log("More than 1 instance");
		instance = this;
	}

	private void Start()
    {
        day = 0;
    }

	public static GameManager GetInstance()
	{
		return instance;
	}

	public void StartDayTransition()
    {

        ++day;
        dayPanel.GetComponentInChildren<TextMeshProUGUI>().text = "DAY " + day;
        dayPanel.SetActive(true);
        Invoke("EndDayTransition", 3);
    }

    public void EndDayTransition()
    {
        dayPanel.SetActive(false);
        dialoguePanel.SetActive(true );
        aiStoryElements[day - 1].TriggerStory();     //current day story
    }

    public void StartObstacleGame()
    {
        dialoguePanel.SetActive(false);
		introGamePanel.SetActive(true);
    }
}
