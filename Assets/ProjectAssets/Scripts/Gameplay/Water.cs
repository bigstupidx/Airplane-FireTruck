using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour
{
	void Update ()
	{
		if (transform.position.y < 0)
			Destroy(gameObject);
	}
}
