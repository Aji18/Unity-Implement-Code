using System;
using UnityEngine;

namespace SpaceInvader
{
	public class Bullets : MonoBehaviour
	{
		private const float speed = 0.01f;
		private float lifeTime = 5f;
		[SerializeField] private PlayerControlller playerControlller;

		private void DestroySelf()
		{
			this.gameObject.SetActive(false);
			Destroy(gameObject);
		}
		
		private void Awake()
		{
			Invoke("DestroySelf", lifeTime);
			playerControlller.Shooting += OnSHooting;
		}

		private void OnSHooting()
		{
			MoveBulets();
		}

		private void OnDestroy()
		{
			throw new NotImplementedException();
		}

		private void MoveBulets()
		{
			this.transform.Translate(0,1 * speed * Time.deltaTime,0);
		}
	}
}
