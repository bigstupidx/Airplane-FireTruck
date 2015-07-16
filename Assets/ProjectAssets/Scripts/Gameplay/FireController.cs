using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour
{

	public GameObject[] fires;

	void Update ()
	{
		if (Player.I.GetComponent<Rigidbody>().isKinematic)
		{
			int i = 0;

			foreach (GameObject fire in fires)
				if (fire.activeSelf)
					i++;

			if (i == 0)
				Player.I._extinguished = true;
		}
	}
}
