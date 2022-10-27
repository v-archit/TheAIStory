using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    private string introText;
    private string taskText;

    public TextMeshProUGUI introTextHolder;
    public TextMeshProUGUI taskTextHolder;

    public DialogueManager dialogueManager;

    void Start()
    {
        introText = 
            "<size=60>WELCOME!\n\n" +
            "<size=40>You are a programmer investigating an <b>AI.</b>\n" +
            "Your daily duties are given below:";
        taskText =
			"<size=50>\u2022<indent=2em> Daily chat with AI</indent>\n" +
			"\u2022<indent=2em> Daily game with AI</indent>";

        introTextHolder.text = introText;
        taskTextHolder.text = taskText;
    }

    public void StartBossInteraction()
    {

        if (GameManager.GetInstance().bossChancesUsed < GameManager.GetInstance().maxBossChances)
        {
            GameManager.GetInstance().DisablePanels();
            GameManager.GetInstance().StartConversationDay();
            GameManager.GetInstance().SetConversation(2);

            dialogueManager.SetFaceActive(0, 2);

            GameManager.GetInstance().bossStoryElements[GameManager.GetInstance().bossChancesUsed].TriggerStory();
            GameManager.GetInstance().UseBossChance();
        }
        else
        {
			GameManager.GetInstance().SetConversation(1);

		}
	}

    
}
