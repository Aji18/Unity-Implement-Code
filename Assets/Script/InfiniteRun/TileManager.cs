using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace InfiniteRun
{
	public class TileManager : MonoBehaviour
	{
		[SerializeField] private GameObject[] tilePrefabs;
		private float spawnTile = 0;
		private float tileLength = 20;
		private int numberOfTile = 3;
		private List<GameObject> activeTiles = new List<GameObject>();

		[SerializeField]private Transform playerTransform;
		
		
		private void Start()
		{
			
			for (int i = 0; i < numberOfTile; i++)
			{
				if (i == 0)
				{
					SpawnTile(0);
				}
				else
				{
					SpawnTile(Random.Range(0,tilePrefabs.Length));
				}
			}
		}
		
		private void Update()
		{
			if (playerTransform.position.z - 35 > spawnTile - (numberOfTile * tileLength))
			{
				SpawnTile(Random.Range(0,tilePrefabs.Length));
				DeleteTile();
			}
		}

		private void DeleteTile()
		{
			Destroy(activeTiles[0]);
			activeTiles.RemoveAt(0);
		}

		private void SpawnTile(int tileIndex)
		{
			GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * spawnTile, transform.rotation);
			activeTiles.Add(go);
			spawnTile += tileLength;
		}
		
	}
}
