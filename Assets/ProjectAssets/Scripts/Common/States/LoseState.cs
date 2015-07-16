using UnityEngine;

public class LoseState : PauseState
{
    private readonly bool _timerEnded;

    public LoseState(bool timerEnded)
        : base()
    {
        _timerEnded = timerEnded;
    }

    protected override void OnActivate()
    {
        base.OnActivate();

		// Ads counter
		if (PlayerPrefs.GetInt("adsCounter") < 4)
			PlayerPrefs.SetInt("adsCounter", PlayerPrefs.GetInt("adsCounter")+1);
		else
		{
		PlayerPrefs.SetInt("adsCounter", 0);

        AdMobAndroidEventListener.Instance.Request();
        AdMobAndroidEventListener.Instance.ShowAd(true);
		}

        View.Resume.gameObject.SetActive(false);
        View.Restart.gameObject.SetActive(true);
        View.NextLevel.gameObject.SetActive(false);
        View.ExitToMainMenu.gameObject.SetActive(true);

        View.TopText.text = _timerEnded ? "Time out!" : "You crashed!";

        GA.I.LogScreen("Lose");
    }
}
