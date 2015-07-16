using UnityEngine;
using System.Collections;

public class DirectLight : MonoBehaviour
{
	public GameObject FireTrack;
	GameObject[] alls;

	void Awake ()
	{
		/*
		alls = GameObject.FindGameObjectsWithTag("Untagged");

		foreach (GameObject all in alls)
			if (all.GetComponent<MeshRenderer>() != null)
				{
				all.GetComponent<MeshRenderer>().castShadows = false;
				all.GetComponent<MeshRenderer>().receiveShadows = false;
				}
				*/
	}

	void Update ()
	{
		transform.position = FireTrack.transform.position;	
	}
}
