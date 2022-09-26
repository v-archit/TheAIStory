using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : MonoBehaviour
{
    [SerializeField]
    private TextAsset inkText;

    private void Start()
    {
        TriggerStory();
    }

    public void TriggerStory()
    {
        DialogueManager.GetInstance().StartDialogue(inkText);
    }
}
