using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public TextMeshProUGUI gameStatus;
	public GameObject obstaclePanel;
	public GameObject[] obstacleObjects;
	public GameObject aiObject;
	public GameObject doorObject;
	public GameObject stopObstacles;

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
				gameStatus.text = "WELL DONE!";
				Time.timeScale = 0;
			}
			else
			{
				obstaclePanel.SetActive(false);
				ResetObstacleGame();
				GameManager.GetInstance().StartDayTransition();
			}
		}
		if (collision.tag == "DoorTrigger")
		{
			doorObject.transform.position -= new Vector3(1500, 0, 0);
			collision.enabled = false;
			GameObject.FindGameObjectWithTag("DoorTrigger2").GetComponent<BoxCollider2D>().enabled = true;
		}
		if (collision.tag == "DoorTrigger2")
		{
			doorObject.transform.position += new Vector3(1500, 0, 0);
			collision.enabled = false;
			stopObstacles.SetActive(true);
		}
		if (collision.tag == "StopTrigger")
		{
			GameObject.FindGameObjectWithTag("StopAnimObj").GetComponent<Animator>().enabled = true;
			collision.enabled = false;
			Invoke("EndObstacleGame", 12);
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
		gameStatus.text = "WELL DONE!";
		Time.timeScale = 0;
	}

}
