using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager> 
{
	[SerializeField] private Text txtScore,highScore;
	[SerializeField] private GameObject scoreAnimator;
	[SerializeField] private Text txtAnimatedText;
	private int Score = 0;
	//private int oldScore;

	void Start()
	{
		Debug.Log("RwdScorecount- " + StackManager.RwdScorecount);
		Debug.Log("RwdScore- " + GameController.RwdScore);
		Debug.Log("RewardScore- " + GameController.RewardScore);
		if (StackManager.RwdScorecount==1)
        {
			txtScore.text = GameController.RwdScore;
			Score = GameController.RewardScore;
		}
        else
        {
			txtScore.text = Score.ToString();
		}	
        highScore.text = PlayerPrefs.GetInt("BestScore_" + GameController.gameMode.ToString()).ToString ();  
	}

	public void AddScore(int scoreToAdd, bool doAnimate = true)
	{
        if (StackManager.RwdScorecount == 1)
        {
			Debug.Log("Score - " + Score);
			int oldScore = GameController.RewardScore;
			Score += scoreToAdd;
			StartCoroutine(SetScore(oldScore, Score));
		}
        else
        {
			int oldScore = Score;
			Score += scoreToAdd;
			StartCoroutine(SetScore(oldScore, Score));
		}
		
		if (doAnimate) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = 0;
			scoreAnimator.transform.position = mousePos;
			txtAnimatedText.text = "+" + scoreToAdd.ToString ();
			scoreAnimator.SetActive (true);
		}
	}

	public int GetScore()
	{
		return Score;
	}

	IEnumerator SetScore(int lastScore, int currentScore)
	{
		int IterationSize = (currentScore - lastScore) / 10;

		for (int index = 1; index < 10; index++) {
			lastScore += IterationSize;
			txtScore.text =  string.Format("{0:#,#.}", lastScore);
			yield return new WaitForEndOfFrame ();
		}
		txtScore.text =  string.Format("{0:#,#.}", currentScore);
		yield return new WaitForSeconds (1F);
         GameController.RwdScore= string.Format("{0:#,#.}", currentScore);
        GameController.RewardScore= currentScore;
		scoreAnimator.SetActive (false);
	}
}
