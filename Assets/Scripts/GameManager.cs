
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    delegate void PostConversation();
    PostConversation postConversation;

    public GameObject dayPanel;
    public GameObject dialoguePanel;
    public GameObject introGamePanel;
    public GameObject obstaclePanel;
    public GameObject surveyPanel;
    public GameObject pausePanel;
    public GameObject taskObject;
    public StoryElement[] aiStoryElements;
    public StoryElement[] bossStoryElements;
    public int day { get; private set; }
    public int bossChancesUsed { get; private set; }

	private static GameManager instance;
    public DialogueManager dialogueManager;

    private bool taskBool = false;
    private bool pauseBool = false;
    public int maxBossChances { get; private set; }

	private void Awake()
	{
		if (instance != null)
			Debug.Log("More than 1 instance");
		instance = this;
	}

	private void Start()
    {
        day = 0;
		bossChancesUsed = 0;
        maxBossChances = 3;

	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (taskBool == false)
            {
				taskObject.SetActive(true);
                taskBool = true;
            }
            else
            {
				taskObject.SetActive(false);
                taskBool = false;
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (pauseBool == false)
			{
				pausePanel.SetActive(true);
				pauseBool = true;
			}
			else
			{
				pausePanel.SetActive(false);
				pauseBool = false;
			}
		}
	}

    public void StartConversationDay()
    {
        dialoguePanel.SetActive(true);
    }

    public static GameManager GetInstance()
	{
		return instance;
	}

    public void SetConversation(int face)
    {
        switch (face)
        {
            case 1:
                postConversation = StartObstacleGame;
                 break;
            case 2:
                postConversation = StartDayTransition;
                break;
        }
    }

    public void StartPostConversation()
    {
        postConversation();
    }

	public void StartDayTransition()
    {
        DisablePanels();
		++day;
        dayPanel.GetComponentInChildren<TextMeshProUGUI>().text = "DAY " + day;
        dayPanel.SetActive(true);
        Invoke("EndDayTransition", 3);
    }


    public void EndDayTransition()
    {
        DisablePanels();
		dialoguePanel.SetActive(true);
        dialogueManager.SetFaceActive(0, 1);
        //Letting Manager know AI conversation is happening
        SetConversation(1);
        aiStoryElements[day - 1].TriggerStory();     //current day story
    }
    public void DisablePanels()
    {
		surveyPanel.SetActive(false);
		dialoguePanel.SetActive(false);
        introGamePanel.SetActive(false);
		obstaclePanel.SetActive(false);
        dayPanel.SetActive(false);
	}

    public void StartObstacleGame()
    {
		DisablePanels();
		introGamePanel.SetActive(true);
    }

    public void UseBossChance()
    {
        ++bossChancesUsed;
    }

	public void StartSurvey()
    {
        surveyPanel.SetActive(true);
    }
}
