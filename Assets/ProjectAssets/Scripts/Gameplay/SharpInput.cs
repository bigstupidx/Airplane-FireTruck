using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SharpInput : MonoBehaviour {
    private CarTouchExternalInput _input;
    private float _steer;
    private float _curSteer;
    private float _motor;
    private float _targetSteer;
    private int standBrake;
	private int _direction;

	public GameObject _buttons;
	public Sprite Left;
	public Sprite Right;
	public Sprite Default;
	public GameObject GearBox;

	void Start ()
	{
        _input = GetComponent<CarTouchExternalInput>();

		if (PlayerPrefs.GetInt("Control") == 1)
			_buttons.SetActive(true);
		else 
			_buttons.SetActive(false);
	}
	
	void Update ()
	{
        float xVel = transform.InverseTransformDirection(rigidbody.velocity).z;

        _curSteer = Mathf.Lerp(_curSteer, _steer, Time.deltaTime * 5f);
        _input.steer = _curSteer;
        _input.brake = (_motor < 0 && xVel > 0.03f) || (_motor > 0 && xVel < -0.03f) ? 1 : 0;

	    if (_input.brake != 1)
			_input.acceleration = _motor;
	    else
	        _input.acceleration = 0;

	    if (standBrake == 1)
	        _input.brake = standBrake;
	}

    public void Steer(float v)
    {
        _steer = v;

		if (v < 0)
			_buttons.GetComponent<Image>().sprite = Left;
		else if (v > 0)
			_buttons.GetComponent<Image>().sprite = Right;
		else
			_buttons.GetComponent<Image>().sprite = Default;
	}
	
	public void Motor(float v)
	{
		_motor = v * _direction;
	}
	
	public void Break(int v)
	{
		standBrake = v;
	}

	public void SwitchGear(int v)
	{
		_direction = v;

		if (v < 0)
			GearBox.transform.localPosition = new Vector3(-51,-147,0);
		else
			GearBox.transform.localPosition = new Vector3(-51,152,0);
	}
}
