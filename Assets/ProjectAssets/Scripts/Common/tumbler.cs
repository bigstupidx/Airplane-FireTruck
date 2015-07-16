using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tumbler : MonoBehaviour
{
	public Sprite tumbler_l;
	public Sprite tumbler_r;

	void Awake ()
	{
		if (PlayerPrefs.GetInt("firstLaunch") == 0)
		{
			PlayerPrefs.SetInt("firstLaunch",1);
			if (name != "Control")
				PlayerPrefs.SetInt(name, 1);
		}
	}

	void Start ()
	{
		if (PlayerPrefs.GetInt(name) == 0)
			GetComponent<Image>().sprite = tumbler_l;
		else
			GetComponent<Image>().sprite = tumbler_r;
	}

	public void Toggle ()
	{
		if (GetComponent<Image>().sprite == tumbler_l)
		{
			PlayerPrefs.SetInt(name, 1);
			GetComponent<Image>().sprite = tumbler_r;
		}
		else
		{
			PlayerPrefs.SetInt(name, 0);
			GetComponent<Image>().sprite = tumbler_l;
		}
	}
}
