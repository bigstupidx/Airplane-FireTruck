using UnityEngine;
using System.Collections;

public class ResetExplosion : MonoBehaviour {
	
	private ParticleSystem Explosion;
	private float TimeElapsed = 0;
	
	// Use this for initialization
	void Start () 
	{
		Explosion = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
	}
	
	void PlayExplosion()
	{
		if ( Explosion != null )
			Explosion.Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
		TimeElapsed += Time.deltaTime;
		
		if ( TimeElapsed > 2 )
		{
			TimeElapsed = 0;
			PlayExplosion();
		}
	}
}
