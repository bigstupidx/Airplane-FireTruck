using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.ProjectAssets.Scripts.Common.States
{
    class LevelWinState:PauseState
    {
        protected override void OnActivate()
        {
            base.OnActivate();

            View.Resume.gameObject.SetActive(false);
            View.Restart.gameObject.SetActive(false);


            if (LevelControl.I.Levels.Count+1 > LevelControl.CurrentLevel)
            {

                View.NextLevel.gameObject.SetActive(true);
				if (Level.Instance.TimeToEnd - Level.Instance._elapsed < 5)
					{
					if (PlayerPrefs.GetInt("Level" + LevelControl.CurrentLevel) < 2)
						PlayerPrefs.SetInt("Level" + LevelControl.CurrentLevel, 2);

						GameObject.Find("NextLevelButton").transform.Find("star2").gameObject.SetActive(false);
						GameObject.Find("NextLevelButton").transform.Find("star3").gameObject.SetActive(false);
					}
				else if (Level.Instance.TimeToEnd - Level.Instance._elapsed < 10)
					{
					if (PlayerPrefs.GetInt("Level" + LevelControl.CurrentLevel) < 3)
						PlayerPrefs.SetInt("Level" + LevelControl.CurrentLevel, 3);

						GameObject.Find("NextLevelButton").transform.Find("star3").gameObject.SetActive(false);
					}
				else
					{
					if (PlayerPrefs.GetInt("Level" + LevelControl.CurrentLevel) < 4)
						PlayerPrefs.SetInt("Level" + LevelControl.CurrentLevel, 4);
					}

				if (PlayerPrefs.GetInt("Level" + (LevelControl.CurrentLevel+1)) == 0)
					PlayerPrefs.SetInt("Level" + (LevelControl.CurrentLevel+1), 1);

				// show stars
				int timeMinutes;
				int timeSeconds;
				
				timeSeconds = (int)(Level.Instance._elapsed);
				timeMinutes = timeSeconds/60;
				timeSeconds -= timeMinutes*60;

				if (timeSeconds > 9)
					GameObject.Find("NextLevelButton").transform.Find("levelTime").GetComponent<Text>().text = timeMinutes + ":" + timeSeconds;
				else
					GameObject.Find("NextLevelButton").transform.Find("levelTime").GetComponent<Text>().text = timeMinutes + ":0" + timeSeconds;
					
			}
            else
            {
                View.NextLevel.gameObject.SetActive(false);
            }
            View.ExitToMainMenu.gameObject.SetActive(true);
            EventController.I.Subscribe("NextLevelClicked", this);

            View.TopText.text = "You won!";
            GA.I.LogScreen("Win");
        }

        protected override void OnDeactivate()
        {
            base.OnDeactivate();
            EventController.I.Unsubscribe("NextLevelClicked", this);
        }

        public override void OnEvent(string EventName, GameObject Sender)
        {
            base.OnEvent(EventName, Sender);

            if (EventName == "NextLevelClicked")
            {
                UIRoot.I.GetView<LoadingView>().SetVisible(true);

                AppRoot.I.SetState(new PlayState(true, true));

				AdMobAndroidEventListener.Instance.Request();
				AdMobAndroidEventListener.Instance.ShowAd(true);
			}
        }
    }
}
