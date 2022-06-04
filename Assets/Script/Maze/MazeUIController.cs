using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
	public class MazeUIController : MonoBehaviour
	{
		[SerializeField] private GameObject textGameOver;
		[SerializeField] private GameObject textFinish;
		[SerializeField] private TextMeshProUGUI textTimer;
		[SerializeField] private MazePlayerController mazePlayerController;

		private const int time = 30;

		private void Start()
		{
			mazePlayerController.isFinish += OnIsFinish;
		}

		private void OnIsFinish()
		{
			textFinish.SetActive(true);
		}

		private void Update()
		{
			throw new NotImplementedException();
		}

		private void Timer()
		{
			  
		}
	}
}
