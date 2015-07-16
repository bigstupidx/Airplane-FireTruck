using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
	public bool extinguish;
	float _timer = 0.5f;
	float _maxIntensity = 8;
	bool _increase = true;

	ParticleSystem[] ps;

	void Awake ()
	{
		ps = GetComponentsInChildren<ParticleSystem>();
	}

	void OnTriggerEnter(Collider collider)
	{
		if (GetComponent<ParticleSystem>().maxParticles > 1)
			{
			foreach (ParticleSystem pss in ps)
				pss.maxParticles -= 3;

			_maxIntensity -= 0.05f;
			}
		else
			extinguish = true;
	}

	void Update()
	{
		if (extinguish)
			_timer -= Time.deltaTime;

		if (_timer < 0)
			gameObject.SetActive(false);

		GetComponent<Light>().intensity = _maxIntensity;
	}

}
