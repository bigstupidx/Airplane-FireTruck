using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class nameSwap : MonoBehaviour
{
	public GameObject _resumeButton;
	public GameObject _restartButton;
	public Sprite win;
	public Sprite lose;

	void Start ()
	{
		if (!_restartButton.activeSelf)
		{
			GetComponent<Image>().sprite = win;
		}
		else if (!_resumeButton.activeSelf)
		{
			GetComponent<Image>().sprite = lose;
		}
	}
}
