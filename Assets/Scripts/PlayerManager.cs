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
	}

	public void ResetObstacleGame()
	{
		//reset player position and rotation
		transform.localPosition = new Vector3(-405.0f, -54.0f, 0.0f);

		//reset ai position and rotation
		aiObject.transform.localPosition = new Vector3(301.0f, -93.0f, 0.0f);

		//reset obstacles depending upon day
		foreach (GameObject obstacle in obstacleObjects)
			obstacle.SetActive(false);
		obstacleObjects[GameManager.GetInstance().day].SetActive(true); 
	}

}
