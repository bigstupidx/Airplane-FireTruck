using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private CarSound _carSound;
    public PointDirection Arrow;
	bool _parked;
    bool _finished;
	public bool _extinguished;
	Camera camera;
	GameObject WaterPump;
	public GameObject WaterCollider;
	public Transform aimPoint;
	public GameObject[] backLights;
	public GameObject tutorial;

	int waterCounter;

	void Start ()
	{
		_carSound = GetComponent<CarSound>();
	    I = this;
		camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		WaterPump = GameObject.Find("Water");
		WaterPump.SetActive(false);
	}
	
	void Update () 
    {
	    if (_parked)
	    {
			if (LevelControl.CurrentLevel == 0) tutorial.SetActive(true);

	        if (rigidbody.velocity.magnitude < 1 && !_finished)
	        {
				// start extinguish
				GameObject.Find("CameraRoot").GetComponent<CameraRoot>().ExtinguishCamera();
				GetComponent<Rigidbody>().isKinematic = true;
				_carSound.enabled = false;

				transform.position = GameObject.Find("ParkingSpot").transform.position;
				transform.rotation = GameObject.Find("ParkingSpot").transform.rotation;
				_parked = false;

				GameObject[] hideUIs = GameObject.FindGameObjectsWithTag("hideui");

				foreach (GameObject hideUI in hideUIs)
					hideUI.SetActive(false);

				WaterPump.SetActive(true);
			}
	    }

		// watering fire
		if (GetComponent<Rigidbody>().isKinematic)
		{
			if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			Vector3 p = camera.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 50));
			aimPoint.position = p;
			aimPoint.Translate(new Vector3(0,5,0));

			WaterPump.transform.LookAt(aimPoint);
		}
			if (waterCounter < 3)
				waterCounter++;
			else
			{
			GameObject clone =
				Instantiate(WaterCollider, WaterPump.transform.position, WaterPump.transform.rotation) as GameObject;
			clone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 4000);
				waterCounter = 0;
			}
		}

		// win state
		if (_extinguished)
		{
			LevelControl.I.FinishLevel();
			_finished = true;

			GameObject[] waterColliders;
			waterColliders = GameObject.FindGameObjectsWithTag("water");

			foreach (GameObject waterCollider in waterColliders)
				Destroy(waterCollider.gameObject);
			
			GetComponent<Rigidbody>().isKinematic = false;
		}
	}

	public void BackLights (bool set)
	{
		if (set)
		{
			foreach (GameObject backLight in backLights)
				backLight.SetActive(true);
		}
		else
		{
			foreach (GameObject backLight in backLights)
				backLight.SetActive(false);
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("Floor"))
        LevelControl.I.FailLevel();
    }

    void OnTriggerEnter(Collider collider)
    {
        var parking = collider.GetComponent<ParkingCollider>();
        if (parking)
        {
            //if (parking.FirstCollider)
            {
                _parked = true;
            }
        }

    }

    void OnTriggerExit(Collider collider)
    {
        var parking = collider.GetComponent<ParkingCollider>();
        if (parking)
        {
            //if (parking.FirstCollider)
            _parked = false;
        }
    }

    public static Player I { get; private set; }
}
