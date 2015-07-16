using UnityEngine;
using System.Collections;

public class tutorial : MonoBehaviour
{
	float _size;
	bool _bigger;

	void Update ()
	{

		if (_size > 1)
			_bigger = false;
		else if (_size < 0.5f)
			_bigger = true;

		if (_bigger)
			_size += 0.01f;
		else
			_size -= 0.01f;

		transform.localScale = new Vector3(_size,_size,1);

	}
}
