using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InfiniteRun
{
	public class PlayerController : MonoBehaviour
	{
		private CharacterController controller;
		[SerializeField] private float forwardSpeed = 10f;

		private int desiredLane = 1; //0=left, 1=mid, 2=right
		[SerializeField] private float laneDistance = 4; //the distance beetwen two lanes

		private Vector3 direction;
		// Start is called before the first frame update
		void Start()
		{
			controller = GetComponent<CharacterController>();
		}

		private void Update()
		{
			direction.z = forwardSpeed;

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

			Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
			if (desiredLane == 0)
			{
				targetPosition += Vector3.left * laneDistance;
			}
			else if (desiredLane == 2)
			{
				targetPosition += Vector3.right * laneDistance;
			}

			transform.position =Vector3.Lerp(transform.position,targetPosition,80 *Time.fixedDeltaTime); //targetPosition;
		}

		private void FixedUpdate()
		{
			controller.Move(direction * Time.fixedDeltaTime);
		}
		
		
	}
}
