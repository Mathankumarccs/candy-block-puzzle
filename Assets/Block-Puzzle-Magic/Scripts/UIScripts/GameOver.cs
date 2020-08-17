using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	[SerializeField] Text txtScore;
	[SerializeField] private Text txtBestScore;
	[SerializeField] private Text txtCoinReward;

	public void SetLevelScore(int score, int coinReward)
	{
		int bestScore = PlayerPrefs.GetInt ("BestScore_" + GameController.gameMode.ToString (), score);

		if (score >= bestScore) {
			PlayerPrefs.SetInt ("BestScore_" + GameController.gameMode.ToString (), score);
		}

		txtScore.text = string.Format("{0:#,#.}", score.ToString("0"));
        txtBestScore.text = string.Format("{0:#,#.}", (PlayerPrefs.GetInt("BestScore_" +
                                                                          GameController.gameMode.ToString()).ToString("0")));
		txtCoinReward.text = string.Format("{0:#,#.}", coinReward.ToString("0"));

		CurrencyManager.Instance.AddCoinBalance (coinReward);
	}

	public void RewadVideo(int score, int coinReward)
	{
		int bestScore = PlayerPrefs.GetInt("BestScore_" + GameController.gameMode.ToString(), score);

		if (score >= bestScore)
		{
			PlayerPrefs.SetInt("BestScore_" + GameController.gameMode.ToString(), score);
		}

		txtScore.text = string.Format("{0:#,#.}", score.ToString("0"));
		txtBestScore.text = string.Format("{0:#,#.}", (PlayerPrefs.GetInt("BestScore_" +
																		  GameController.gameMode.ToString()).ToString("0")));
		txtCoinReward.text = string.Format("{0:#,#.}", coinReward.ToString("0"));

		CurrencyManager.Instance.AddCoinBalance(coinReward);

		txtBestScore.text += 100;
	}

	public void OnHomeButtonPressed()
	{
		if (InputManager.Instance.canInput ()) {
			AudioManager.Instance.PlayButtonClickSound ();
			StackManager.Instance.OnCloseButtonPressed ();
		}
	}

	public void OnReplayButtonPressed()
	{
		if (InputManager.Instance.canInput ()) {
			AudioManager.Instance.PlayButtonClickSound ();
			StackManager.Instance.RestartGamePlay ();
			StackManager.RwdScorecount = 0;
			BannerAds.Instance.DestroyBannerAd();
		}
	}

    public void Rate()
    {
        Application.OpenURL("https://itunes.apple.com/us/app/jewel-duluxe-block-puzzle/id1409060724?ls=1&mt=8");
    }
}
