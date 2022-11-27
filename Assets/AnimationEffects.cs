using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AnimationEffects : MonoBehaviour
{
	private Animator animator;
	private bool isAnimPlaying;

	private int killCounter;
	private int saveCounter;

	public List<GameObject> killObjects;
	public List<GameObject> saveObjects;

	private void Start()
	{
		animator = GetComponent<Animator>();
		killCounter = 0;
		saveCounter = 0;
		DisplayKillObject();
		DisplaySaveObject();
	}

	private void Update()
	{
		isAnimPlaying = animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f;
	}

	public void PlayKillAnimation(string obj)
    {
		if (!isAnimPlaying)
		{
			if (obj == "hammer")
			{
				GetComponent<Animator>().Play("Kill_Hammer", 0, 0.0f);
			}
			else if (obj == "lightning")
			{
				GetComponent<Animator>().Play("Kill_Lighting", 0, 0.0f);
			}
			else if (obj == "grenade")
			{
				GetComponent<Animator>().Play("Kill_Grenade", 0, 0.0f);
			}
		}
	}

	public void PlaySaveAnimation(string obj)
	{
		if (!isAnimPlaying)
		{
			if (obj == "rotate")
			{
				GetComponent<Animator>().Play("Save_Rotate", 0, 0.0f);
			}
			else if (obj == "screwdriver")
			{
				GetComponent<Animator>().Play("Save_Screwdriver", 0, 0.0f);
			}
			else if (obj == "meter")
			{
				GetComponent<Animator>().Play("Save_Meter", 0, 0.0f);
			}
			else if (obj == "remove")
			{
				GetComponent<Animator>().Play("Save_Remove", 0, 0.0f);
			}
			else if (obj == "replace")
			{
				GetComponent<Animator>().Play("Save_Replace", 0, 0.0f);
			}
		}
	}

	public void NextKillObject()
	{
		if (!isAnimPlaying)
		{
			IncCounter(true);
			DisplayKillObject();
		}
	}

	public void NextSaveObject()
	{
		if (!isAnimPlaying)
		{
			IncCounter(false);
			DisplaySaveObject();
		}
	}

	private void IncCounter(bool kill)
	{
		if (kill)
			++killCounter;
		else
			++saveCounter;
	}

	private void DisplayKillObject()
	{
		foreach (GameObject gameObject in killObjects)
			gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
		if (killCounter < killObjects.Count)
		{
			killObjects[killCounter].GetComponent<UnityEngine.UI.Button>().interactable = true;
		}
		else
		{

		}
	}

	private void DisplaySaveObject()
	{
		foreach (GameObject gameObject in saveObjects)
			gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
		if (saveCounter < saveObjects.Count)
		{
			saveObjects[saveCounter].GetComponent<UnityEngine.UI.Button>().interactable = true;
		}
		else
		{

		}
	}

}
