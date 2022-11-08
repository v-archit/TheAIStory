using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Ink.Runtime;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private TextMeshProUGUI nameTextRight;
	//[SerializeField]
	//private GameObject dialoguePanel;
	[Header("Choices UI")]
	[SerializeField]
	private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    [SerializeField]
    private GameObject[] faceObject;

    [SerializeField]
    private GameObject continueButton;

	[SerializeField]
	private GameObject[] bgScreens;

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
		continueButton.SetActive(true);

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
                    SetFaceAndName();
					dialogueText.fontStyle = FontStyles.Normal;
					break;
				case 2:
					SetFaceAndName();
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

        GameManager.GetInstance().StartPostConversation();

        //Debug.Log("Conversation ended");
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count != 0)
        {
            isChoicePresent = true;
            continueButton.SetActive(false);
        }

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


    private void SetFaceAndName()
    {
		switch (currentStory.currentTags[0])
		{
			case "Programmer":
                SetFaceInactive();
				Color temp1 = faceObject[0].GetComponent<Image>().color;
				faceObject[0].GetComponent<Image>().color = new Color(temp1.r, temp1.g, temp1.b, 1.0f);
				break;
			case "AI":
				SetFaceInactive();
				Color temp2 = faceObject[1].GetComponent<Image>().color;
                Debug.Log("AI");
				faceObject[1].GetComponent<Image>().color = new Color(temp2.r, temp2.g, temp2.b, 1.0f);
				nameTextRight.text = "AI";
				break;
			case "Boss":
				SetFaceInactive();
				Color temp3 = faceObject[2].GetComponent<Image>().color;
				Debug.Log("Boss");

				faceObject[2].GetComponent<Image>().color = new Color(temp3.r, temp3.g, temp3.b, 1.0f);
				nameTextRight.text = "Boss";
				break;
		}
	}

    private void SetFaceInactive()
    {
		foreach (GameObject face in faceObject)
		{
			Color temp = face.GetComponent<Image>().color;
			face.GetComponent<Image>().color = new Color(temp.r, temp.g, temp.b, 0.4f);
		}
	}

    private void SetFaceAndBGDisable()
    {
		foreach (GameObject face in faceObject)
		{
			face.SetActive(false);
		}
		foreach (GameObject bg in bgScreens)
		{
			bg.SetActive(false);
		}
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

    public void SetFaceActive(int face1, int face2)
    {
		SetFaceAndBGDisable();

        faceObject[face1].SetActive(true);
        faceObject[face2].SetActive(true);

        bgScreens[face2-1].SetActive(true);
    }

    
}
