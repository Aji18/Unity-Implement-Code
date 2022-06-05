using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

namespace SpaceInvader
{
	public class PlayerControlller : MonoBehaviour
	{
		private const float speed = 0.01f;

		[SerializeField] private GameObject bullet;
		public Action Shooting;
		// Start is called before the first frame update
		private void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{
			MovePlayer();
			Shoot();
		}

		private void MovePlayer()
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				this.transform.Translate(-1 * speed, 0, 0);
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				this.transform.Translate(1 * speed,0,0);
			}

			if (Input.GetKey(KeyCode.UpArrow))
			{
				this.transform.Translate(0,1 * speed,0);

			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				this.transform.Translate(0,-1 * speed,0);	
			}
		}

		private void Shoot()
		{
			if (Input.GetKey(KeyCode.Space))
			{
				Debug.Log("Tembak");
				Shooting?.Invoke();
			}
		}
	}
}
