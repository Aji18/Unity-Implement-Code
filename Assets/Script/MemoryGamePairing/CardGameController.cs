using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MemoryGamePairing
{
	public class CardGameController : MonoBehaviour
	{
		[SerializeField] private Sprite cardImage;
		[SerializeField] private Sprite[] puzzles;
		[SerializeField] private GameObject cardObjek;
		
		[SerializeField] private List<Button> cardsButton = new List<Button>();
		[SerializeField] private List<Sprite> spriteCard = new List<Sprite>();

		private bool firstCard;
		private bool secondCard;

		private int countGuesses;
		private int countCorrectGuesses;
		private int gameGuesses;

		private int firstGuessIndex;
		private int secondGuessIndex;

		private string firsrGuessPuzzle;
		private string secondGuessPuzzle;

		void Start()
		{
			GetButton();
			AddListeners();
			AddGamePuzzles();
		}

		private void Awake()
		{
			puzzles = Resources.LoadAll<Sprite>("");
		}

		private void GetButton()
		{
			//GameObject[] objects = cardObjek[i].GetComponent<GameObject>();
			GameObject[] objects = GameObject.FindGameObjectsWithTag("a");
			
			for (int i = 0; i < 8; i++)
			{
				cardsButton.Add(objects[i].GetComponent<Button>());
				cardsButton[i].image.sprite = cardImage;
			}
		}

		private void AddGamePuzzles()
		{
			int looper = cardsButton.Count;
			int index = 0;
			for (int i = 0; i < looper; i++)
			{
				if (index == looper/2)
				{
					index = 0;
				}
				
				spriteCard.Add(puzzles[index]);
				index++;
			}
		}

		private void AddListeners()
		{
			foreach (Button btn in cardsButton)
			{
				btn.onClick.AddListener(() => SelectCard());
			}
		}
		

		private void SelectCard()
		{
			if (firstCard)
			{
				firstCard = true;
				firstGuessIndex =
					int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
				firsrGuessPuzzle = spriteCard[firstGuessIndex].name;
				cardsButton[firstGuessIndex].image.sprite = spriteCard[firstGuessIndex];
			}
			else if (!secondCard)
			{
				secondCard = true;
				secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
				secondGuessPuzzle = spriteCard[secondGuessIndex].name;
				cardsButton[secondGuessIndex].image.sprite = spriteCard[secondGuessIndex];

				if (firsrGuessPuzzle == secondGuessPuzzle)
				{
					Debug.Log("puzzle match");
				}
				else
				{
					Debug.Log("Puzzle not match");
				}
			}
			
		}
	}
}
