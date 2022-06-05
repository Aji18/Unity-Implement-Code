using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace MemoryGamePairing
{
	public class CardGameController : MonoBehaviour
	{
		[SerializeField] private Sprite backCardImage;
		[SerializeField] private Sprite[] cardForPuzzles;
		//[SerializeField] private GameObject cardObjek;
		
		[SerializeField] private List<Button> cardsButton = new List<Button>();
		[SerializeField] private List<Sprite> spriteCard = new List<Sprite>();

		[SerializeField] private GameObject textDone;
		[SerializeField] private GameObject buttonRestart;

		private bool firstGuess;
		private bool secondGuess;

		private int countGuesses;
		private int countCorrectGuesses;
		private int gameGuesses;

		private int firstGuessIndex;
		private int secondGuessIndex;

		private string firsrGuessPuzzle;
		private string secondGuessPuzzle;

		void Start()
		{
			Debug.Log("first guess" + firstGuess);
			GetButton();
			AddListeners();
			AddGamePuzzles();
			Shuffle(spriteCard);
			gameGuesses = spriteCard.Count / 2;
		}

		private void Awake()
		{
			cardForPuzzles = Resources.LoadAll<Sprite>("Sprite/Cards/");
		}

		private void GetButton()
		{
			//GameObject[] objects = cardObjek[i].GetComponent<GameObject>();
			GameObject[] objects = GameObject.FindGameObjectsWithTag("a");
			
			for (int i = 0; i < objects.Length; i++)
			{
				cardsButton.Add(objects[i].GetComponent<Button>());
				cardsButton[i].image.sprite = backCardImage;
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
				spriteCard.Add(cardForPuzzles[index]);
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
			if (!firstGuess)
			{
				firstGuess = true;
				firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
				firsrGuessPuzzle = spriteCard[firstGuessIndex].name;
				cardsButton[firstGuessIndex].image.sprite = spriteCard[firstGuessIndex];
			} 
			else if (!secondGuess)
			{
				secondGuess = true;
				secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
				secondGuessPuzzle = spriteCard[secondGuessIndex].name;
				cardsButton[secondGuessIndex].image.sprite = spriteCard[secondGuessIndex];
				countGuesses++;
				Debug.Log(countGuesses);
				StartCoroutine(CheckIfThePuzzleMatch());
			}
			
		}

		IEnumerator CheckIfThePuzzleMatch()
		{
			yield return new WaitForSeconds(1f);
			if (firsrGuessPuzzle == secondGuessPuzzle)
			{
				yield return new WaitForSeconds(0.5f);

				cardsButton[firstGuessIndex].interactable = false;
				cardsButton[secondGuessIndex].interactable = false;

				//cardsButton[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
				//cardsButton[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
				
				GameFinish();
			}
			else
			{
				yield return new WaitForSeconds(0.5f);
				
				cardsButton[firstGuessIndex].image.sprite = backCardImage;
				cardsButton[secondGuessIndex].image.sprite = backCardImage;
			}

			yield return new WaitForSeconds(0.5f);
			firstGuess = secondGuess = false;
		}

		private void GameFinish()
		{
			countCorrectGuesses++;
			if (countCorrectGuesses == gameGuesses)
			{
				Debug.Log("Game FInished");
				textDone.SetActive(true);
				buttonRestart.SetActive(true);
				cardForPuzzles = null;
				cardsButton = null;
				spriteCard = null;
			}
		}
		
		private void Shuffle(List<Sprite> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Sprite temp = list[i];
				int randomIndex = Random.Range(i, list.Count);
				list[i] = list[randomIndex];
				list[randomIndex] = temp;
			}
		}

		public void Restart()
		{
			textDone.SetActive(false);
			buttonRestart.SetActive(false);
			
			
		}
	}
}
