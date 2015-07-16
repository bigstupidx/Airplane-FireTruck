
    using System.Text;
    using UnityEngine;

public class PlayState : StateBase
{
    private readonly bool _firstStart;
    private HudView _view;

    public PlayState(bool forceReload = false, bool firstStart = false)
        : base("main", forceReload)
    {
        _firstStart = firstStart;
    }

    protected override void OnActivate()
    {
        base.OnActivate();
        _view = UIRoot.I.GetView<HudView>();
        EventController.I.Subscribe("PauseClicked", this);
        EventController.I.Subscribe("ChangeCameraClicked", this);
        UIRoot.I.GetView<HudView>().SetVisible(true);

        if (_firstStart)
        {
            GA.I.LogScreen("Level" + GameSaver.I.CurrentLevel);
        }
    }

    protected override void OnDeactivate()
    {
        base.OnDeactivate();
        UIRoot.I.GetView<HudView>().SetVisible(false);

        EventController.I.Unsubscribe("PauseClicked", this);
        EventController.I.Unsubscribe("ChangeCameraClicked", this);
    }

    public override void Update()
    {
        base.Update();
        if (Level.Instance != null)
        {
			int timeMinutes;
			int timeSeconds;

			timeSeconds = (int)(Level.Instance.TimeToEnd - Level.Instance._elapsed);
			timeMinutes = timeSeconds/60;
			timeSeconds -= timeMinutes*60;

            if(_view != null)
				if (timeSeconds > 9)
					_view.TimeText.text = timeMinutes + ":" + timeSeconds;
				else
				_view.TimeText.text = timeMinutes + ":0" + timeSeconds;
        }
    }

    public override void OnEvent(string EventName, GameObject Sender)
    {
        base.OnEvent(EventName, Sender);
        if (EventName == "PauseClicked")
        {
            AppRoot.I.SetState(new PauseState());
        }        
        if (EventName == "ChangeCameraClicked")
        {
            CameraRoot.I.NextCamera();
        }
    }
}
