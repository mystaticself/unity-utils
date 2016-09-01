using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public Vector3 shakeDistance = Vector3.one;
	public float strength = 1f;
	public bool useOrigin = true;
	public bool shakeOnStart = false;

	private Transform _transform;
	private Vector3 _origin;
	private Vector3 _targetPos;
	private bool _shake = false;
	private float _strength = 0f;
	private float _strengthTarget = 0f;

	void Start () 
	{
		_transform = transform;
		UpdateOrigin();

		if(shakeOnStart)
		{
			Shake(3f);
		}
	}

	void Update () 
	{
		if(_shake)
		{
			_strength = Mathf.Lerp(_strength, _strengthTarget, Time.deltaTime * 3f);

			if(!useOrigin)
			{
				_origin = _transform.position;
			}
			
			_targetPos = _origin + new Vector3(
				Random.Range(-shakeDistance.x, shakeDistance.x) * _strength,
				Random.Range(-shakeDistance.y, shakeDistance.y) * _strength,
				Random.Range(-shakeDistance.z, shakeDistance.z) * _strength
			);

			_transform.localPosition = _targetPos;
		}
		else
		{
			_origin = _transform.localPosition;
		}
	}
	
	public void UpdateOrigin()
	{
		_origin = _transform.localPosition;
	}

	public void Shake(float duration = 1f)
	{
		StartCoroutine(TriggerShake(duration));
	}
	
	public void StartShaking()
	{
		_strengthTarget = strength;
		_shake = true;
	}
	
	public void StopShaking()
	{
		_strengthTarget = 0;
		StartCoroutine(ResetShake());
	}

	private IEnumerator ResetShake()
	{
		yield return new WaitForSeconds(0.6f);
		_shake = false;
	}

	private IEnumerator TriggerShake(float duration)
	{
		StartShaking();

		yield return new WaitForSeconds(duration);

		StopShaking();
		_transform.localPosition = _origin;
	}
}
