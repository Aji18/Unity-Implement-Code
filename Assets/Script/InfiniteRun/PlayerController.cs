using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace InfiniteRun
{
	public class PlayerController : MonoBehaviour
	{
		#region speed

		#endregion

		private const float laneDistance = 2.5f;

		private int desiredLane = 1; //0=left, 1=mid, 2=right
		public Action CrashObject;
		[SerializeField]private Vector3 forwardSpeed = new Vector3(0,0,10);
		private const int valueInterpolate = 1;

		private void Update()
		{

			MovePlayer();

//			Vector3 targetPosition = transform.position.z * transform.forward;
			Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

			targetPosition = new Vector3(0, transform.position.y, transform.position.z);
			if (desiredLane == 0)
			{
				targetPosition += Vector3.left * laneDistance;
			}
			else if (desiredLane == 2)
			{
				targetPosition += Vector3.right * laneDistance;
			}

			transform.position =
				Vector3.Lerp(transform.position, targetPosition,
					valueInterpolate * Time.deltaTime); //pergerakan interpolasi;
		}

		private void MovePlayer()
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				desiredLane++;
				if (desiredLane == 3)
				{
					desiredLane = 2;
				}
			}

			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				desiredLane--;
				if (desiredLane == -1)
				{
					desiredLane = 0;
				}
			}

			//desiredLane = Mathf.Clamp(desiredLane, 0, 2);
		}

		private void FixedUpdate()
		{
			transform.position += (forwardSpeed * Time.fixedDeltaTime);
		}

		private void OnTriggerEnter(Collider other)
		{
			Debug.Log(gameObject.name + " " + other.name);
			CrashObject?.Invoke();
		}
	}
}