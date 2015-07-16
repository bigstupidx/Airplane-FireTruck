using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudView : View
{
    public Text TimeText;

	public GameObject _wheel;
	public GameObject _left;
	public GameObject _right;

	void Awake()
	{
		if (PlayerPrefs.GetInt("Control") == 0)
		{
			_wheel.SetActive(true);
			_left.SetActive(false);
			_right.SetActive(false);
		}
		else
		{
			_wheel.SetActive(false);
			_left.SetActive(true);
			_right.SetActive(true);
		}
	}
}
