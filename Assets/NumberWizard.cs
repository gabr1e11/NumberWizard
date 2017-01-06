using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour {

	public Text guessText;
	public Text liarText;
	public int min;
	public int max;
	public int leftGuesses;

	int guess;
	int liarCount;
	int turn;

	// Use this for initialization
	void Start () {
		min = 0;
		max = 1000;
		guess = (max - min) / 2;
		leftGuesses = 10;
		liarCount = 0;
		liarText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (leftGuesses < 0) {
			SceneManager.LoadScene ("Lose");
			return;
		}

		if (liarCount > 0) {
			liarText.text = "";
			for (int i = 0; i < liarCount; ++i)
				liarText.text += "LIAR!! ";
		}

		guessText.text = "I think your number is: " + guess + "\n";
		guessText.text += "Tries left: " + leftGuesses + "\n";
	}

	private void CalculateNextGuess() {
		leftGuesses--;
		guess = Random.Range(min, max);
	}

	public void OnHigherClick()	{
		if (min == max) {
			liarCount++;
			return;
		}
		liarCount = 0;
		min = guess + 1;
		CalculateNextGuess ();
	}

	public void OnLowerClick() {
		if (min == max) {
			liarCount++;
			return;
		}
		liarCount = 0;
		max = guess - 1;
		CalculateNextGuess ();
	}

	public void OnCorrectClick() {
		SceneManager.LoadScene ("Win");
	}
}
