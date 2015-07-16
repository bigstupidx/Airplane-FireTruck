using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour
{
    public GameObject go;

	void Awake ()
	{
        go.SetActive(true);
	}
}
