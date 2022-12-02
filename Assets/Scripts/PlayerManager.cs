using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public TextMeshProUGUI gameStatus;
	public GameObject[] obstacleObjects;
	public GameObject aiObject;
	public GameObject doorObject;
	public GameObject stopObstacles;
	public GameObject aiDay5Object;
	public TextMeshProUGUI timer;

	public AudioSource sceneChangeAudioSource;
	public AudioSource loseAudioSource;
	public AudioSource taskAudioSource;
	public AudioSource warningAudioSource;

	private Vector3 aiPos, playerPos;
	private void Start()
	{
		aiPos = aiObject.transform.position;
		playerPos = transform.position;
		obstacleObjects[0].SetActive(true);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Door")
		{
			if (GameManager.GetInstance().day > 5)
			{
				//player cannot reach door on day 5
			}
			else
			{
				taskAudioSource.Play();
				GameManager.GetInstance().DisablePanels();
				ResetObstacleGame();
				GameManager.GetInstance().StartSurvey();
			}
		}
		if (collision.tag == "DoorTrigger")
		{
			sceneChangeAudioSource.Play();
			doorObject.transform.position -= new Vector3(1500, 0, 0);
			collision.enabled = false;
			GameObject.FindGameObjectWithTag("DoorTrigger2").GetComponent<BoxCollider2D>().enabled = true;
		}
		if (collision.tag == "DoorTrigger2")
		{
			warningAudioSource.Play();
			doorObject.transform.position += new Vector3(1500, 0, 0);
			collision.enabled = false;
			stopObstacles.SetActive(true);
			aiDay5Object.SetActive(false);
		}
		if (collision.tag == "StopTrigger")
		{
			sceneChangeAudioSource.Play();
			GameObject.FindGameObjectWithTag("StopAnimObj").GetComponent<Animator>().enabled = true;
			collision.enabled = false;
			StartCoroutine(TimerCountdown());
			Invoke("EndObstacleGame", 11);
		}
	}

	private void ResetObstacleGame()
	{
		//reset player position and rotation
		//transform.localPosition = new Vector3(-740.0f, -54.0f, 0.0f);
		transform.position = playerPos;

		//reset ai position and rotation
		//aiObject.transform.localPosition = new Vector3(301.0f, -93.0f, 0.0f);
		//aiObject.transform.position = aiPos;

		//reset obstacles depending upon day
		foreach (GameObject obstacle in obstacleObjects)
			obstacle.SetActive(false);
		obstacleObjects[GameManager.GetInstance().day].SetActive(true); 
	}

	private void EndObstacleGame()
	{
		loseAudioSource.Play();
		gameStatus.text = "WELL DONE!";
		GameManager.GetInstance().StartDayTransition();

	}

	IEnumerator TimerCountdown()
	{
		timer.gameObject.SetActive(true);
		int time = 10;
		while (time >= 0)
		{
			timer.text = "" + time;
			time--;
			yield return new WaitForSeconds(1);
		}
		
		yield break;
	}

}
