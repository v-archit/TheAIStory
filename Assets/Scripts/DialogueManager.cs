using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    Coroutine sentenceCoroutine;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI sentenceText;

    void Start()
    {
        sentences = new Queue<string>();
        sentenceCoroutine = null;

	}

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
		NextSentence();

	}

	public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();

        if (sentenceCoroutine != null)
            StopCoroutine(sentenceCoroutine);

        sentenceCoroutine = StartCoroutine(UpdateSentenceText(sentence));
    }

    public void EndDialogue()
    {
        Debug.Log("Conversation ended");
    }

    IEnumerator UpdateSentenceText(string sentence)
    {
        sentenceText.text = "";

        foreach (char character in sentence.ToCharArray())
        {
            sentenceText.text += character;
            yield return null;
        }

        

    }
}
