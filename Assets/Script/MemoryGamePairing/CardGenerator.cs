using UnityEngine;

namespace MemoryGamePairing
{
	public class CardGenerator : MonoBehaviour
	{
		[SerializeField] private GameObject cardButton;
		[SerializeField] private Transform cardPosition;
		

		private void Awake()
		{
			for (int i = 0; i < 8; i++)
			{
				GameObject button = Instantiate(cardButton);
				button.name = "" + i;
				button.transform.SetParent(cardPosition);
			}
		}

		// Update is called once per frame
	}
}
