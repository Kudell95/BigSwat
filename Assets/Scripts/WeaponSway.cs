using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour {

	public float amount;
	public float maxAmount;
	public float smoothing;
	private float smoothingConst;

	private Vector3 initalPos;

	// Use this for initialization
	void Start () {
		initalPos = transform.localPosition;
		smoothingConst = smoothing;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(Input.GetMouseButtonDown(1))
		{
			smoothing = smoothing/2;
		}else{
			smoothing = smoothingConst;
		}
		float movementX = Input.GetAxis("Mouse X") * amount;
		float movementY = Input.GetAxis("Mouse Y") * amount;
		movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
		movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);
		Vector3 finalPos = new Vector3(movementX, movementY, 0);
		transform.localPosition = Vector3.Lerp(transform.localPosition, finalPos+initalPos, Time.deltaTime * smoothing);
	}
}
