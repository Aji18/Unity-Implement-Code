using System;
using UnityEngine;

namespace Maze
{
	public class MazePlayerController : MonoBehaviour
	{
		private float speed = 0.01f;
		public Action isFinish;

		private void Update()
		{
			Movement();
		}

		private void Movement()
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				this.transform.Translate(-1f * speed, 0, 0);
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				this.transform.Translate(1f * speed, 0, 0);
			}

			if (Input.GetKey(KeyCode.UpArrow))
			{
				this.transform.Translate(0, 1 * speed, 0);
			}

			if (Input.GetKey(KeyCode.DownArrow))
			{
				this.transform.Translate(0, -1 * speed, 0);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			isFinish?.Invoke();
		}
	}
}
