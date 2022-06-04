using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace InfiniteRun
{
	public class UIGame : MonoBehaviour
	{
		private int score;
		[SerializeField] private TextMeshProUGUI TextScore;
		[SerializeField] private TextMeshProUGUI TextLive;
		[SerializeField] private GameObject TextGameOver;
		[SerializeField] private GameObject ButtonRestart;
		[SerializeField] private PlayerController playerController;
		[SerializeField] private TileManager _tileManager;
		[SerializeField] private GameObject player;
		private int live = 3;
		private bool isPause = true;

		public void Start()
		{
			playerController = FindObjectOfType<PlayerController>();
			playerController.CrashObject += OnCrashObject;
			isPause = false;
		}

		private void OnCrashObject()
		{
			live--;
			if (live == 0)
			{
				Debug.Log("Game Over");
				isPause = true;
				Time.timeScale = 0;
				TextGameOver.SetActive(true);
				ButtonRestart.SetActive(true);
			}
		}

		private void OnDestroy()
		{
			playerController.CrashObject -= OnCrashObject;
		}

		// Update is called once per frame
		private void Update()
		{
			score = (int)Time.time;
			TextScore.text = score.ToString();
			TextLive.text = live.ToString();
		}

		public void RestartGame()
		{
			//SceneManager.LoadScene( SceneManager.GetActiveScene().name );
			_tileManager.spawnTile = 0;
			player.transform.position = new Vector3(0, 1.063f, 0);
			live = 3;
			TextGameOver.SetActive(false);
			ButtonRestart.SetActive(false);
			isPause = false;
			playerController.desiredLane = 1;
			Time.timeScale = 1;
		}
	}

}