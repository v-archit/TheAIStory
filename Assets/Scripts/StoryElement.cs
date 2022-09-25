using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerStory()
    {
        GameObject.FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
