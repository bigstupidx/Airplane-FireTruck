using UnityEngine;
using System.Collections;

public class blueLight : MonoBehaviour
{
	bool increase = true;
	public float alpha;
	Color currentColor;
	GameObject mainCamera;

	void Awake ()
	{
		mainCamera = GameObject.Find("Main Camera");
	}

	void Update ()
	{
		transform.LookAt(mainCamera.transform.position);

		if (alpha > 1)
			increase = false;
		if (alpha < 0)
			{
			increase = true;
			currentColor = transform.Find("Graphic").GetComponent<MeshRenderer>().material.GetColor("_TintColor");

			if (currentColor.g == 0)
				currentColor = new Color(1, 0.25f, 0, 0);
			else if (currentColor.g == 0.25f)
				currentColor = new Color(1, 1, 1, 0);
			else
				currentColor = new Color(0.75f, 0, 0, 0);
			}

		if (increase)
			alpha += 0.05f;
		else
			alpha -= 0.05f;

		transform.Find("Graphic").GetComponent<MeshRenderer>().material.SetColor ("_TintColor", new Color(currentColor.r,currentColor.g,currentColor.b,alpha));
	}
}
