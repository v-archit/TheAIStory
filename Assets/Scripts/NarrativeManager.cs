using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeManager : MonoBehaviour
{
    public TextMeshProUGUI introTextHolder;
    public TextMeshProUGUI taskTextHolder;

    public Toggle yToggle;
    public Toggle nToggle;

    public DialogueManager dialogueManager;

    private void Update()
    {

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

    public void SubmitSurvey()
    {
        if (yToggle.isOn)
			StartBossInteraction();
		else if (nToggle.isOn)
        {
            GameManager.GetInstance().StartDayTransition();
        }
		else
		{
            return;
		}
	}

}
