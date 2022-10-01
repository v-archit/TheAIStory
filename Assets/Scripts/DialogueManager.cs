using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private TextMeshProUGUI nameText;
    //[SerializeField]
    //private GameObject dialoguePanel;
    [Header("Choices UI")]
	[SerializeField]
	private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;


	[HideInInspector] public bool isDialoguePlaying { get; private set; }
	[HideInInspector] public bool isChoicePresent { get; private set; }

	private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
            Debug.Log("More than 1 instance");
        instance = this;
    }

	void Start()
	{
        isDialoguePlaying = false;
        isChoicePresent = false;

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>(); 
            index++;
        }
	}

    private void Update()
    {

    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }
    public void StartDialogue(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        isDialoguePlaying = true;

        NextDialogue();
	}
	
    Coroutine dialogueCoroutine;
	
    public void NextDialogue()
    {
        if (isChoicePresent) return;

		if (currentStory.canContinue)
		{
            if(dialogueCoroutine!= null)
                StopCoroutine(dialogueCoroutine);
            //set text for next dialogue
            dialogueCoroutine = StartCoroutine(UpdateDialogueText(currentStory.Continue()));
            switch (currentStory.currentTags.Count)
            {
                case 0:
                    break;
                case 1:
					nameText.text = currentStory.currentTags[0];
					dialogueText.fontStyle = FontStyles.Normal;
					break;
				case 2:
					nameText.text = currentStory.currentTags[0];
					if (currentStory.currentTags[1] == "internal")
						dialogueText.fontStyle = FontStyles.Italic;
					break;
			}
            //display chocies if any
            DisplayChoices();
		}
		else
		{
			EndDialogue();
		}
	}

	IEnumerator UpdateDialogueText(string sentence)
	{
		dialogueText.text = "";

		foreach (char character in sentence.ToCharArray())
		{
			dialogueText.text += character;
			yield return new WaitForSeconds(0.02f);
		}

	}

	public void EndDialogue()
    {
        isDialoguePlaying = false;
        dialogueText.text = "";

        GameManager.GetInstance().StartObstacleGame();

        Debug.Log("Conversation ended");
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count != 0)
			isChoicePresent = true;

		//choices check with UI choices
		if (currentChoices.Count > choices.Length)
            Debug.Log("Not enough UI choices");

		int index = 0;
        //enable and initialize UI choices
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        //hide remaining UI choices
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        //StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);

        isChoicePresent = false;

        NextDialogue();
    }

    
}
