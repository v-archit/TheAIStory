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
    //[SerializeField]
    //private GameObject dialoguePanel;
    [Header("Choices UI")]
	[SerializeField]
	private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool isDialoguePlaying { get; private set; }

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
        if(!isDialoguePlaying) return;

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
		if (currentStory.canContinue)
		{
            if(dialogueCoroutine!= null)
                StopCoroutine(dialogueCoroutine);
            //set text for next dialogue
            dialogueCoroutine = StartCoroutine(UpdateDialogueText(currentStory.Continue()));
			//dialogueText.text = currentStory.Continue();
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
       // Debug.Log("current choices: " + currentChoices.Count + " : " + currentChoices[0].text);

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

        StartCoroutine(SelectFirstChoice());
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
        NextDialogue();
    }

    
}
