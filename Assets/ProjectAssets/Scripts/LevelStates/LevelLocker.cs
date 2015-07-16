using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelLocker : MonoBehaviour
{
	public GameObject locked;
	public GameObject[] stars;

	void Awake ()
	{
		if (PlayerPrefs.GetInt("Level1") == 0)
			PlayerPrefs.SetInt("Level1",1);
	}

	void Start ()
	{
		if (PlayerPrefs.GetInt("Level" + GetComponentInChildren<Text>().text) == 0)
		{
			locked.SetActive(true);
			gameObject.SetActive(false);
		}
		else 
		{

			switch (PlayerPrefs.GetInt("Level" + GetComponentInChildren<Text>().text))
		{
		case 0:
			locked.SetActive(true);
			gameObject.SetActive(false);
			break;
		case 1:
			stars[0].SetActive(false);
			stars[1].SetActive(false);
			stars[2].SetActive(false);
			break;
		case 2:
			stars[0].SetActive(false);
			stars[1].SetActive(false);
			break;
		case 3:
			stars[0].SetActive(false);
			break;
		}

		}
	}
}
