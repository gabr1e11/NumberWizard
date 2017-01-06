using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour {

	public Text guessText;
	public int min;
	public int max;
	public int leftGuesses;

	int guess;

	// Use this for initialization
	void Start () {
		min = 0;
		max = 1000;
		guess = (max - min) / 2;
		leftGuesses = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (leftGuesses == 0) {
			SceneManager.LoadScene ("Lose");
		}
		guessText.text = "I think your number is: " + guess + "\n";
		guessText.text += "Tries left: " + leftGuesses + "\n";
	}

	private void CalculateNextGuess() {
		leftGuesses--;
		guess = (min + max) / 2;
	}

	public void OnHigherClick()	{
		min = guess;
		CalculateNextGuess ();
	}

	public void OnLowerClick() {
		max = guess;
		CalculateNextGuess ();
	}

	public void OnCorrectClick() {
		SceneManager.LoadScene ("Win");
	}
}
