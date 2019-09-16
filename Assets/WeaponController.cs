using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //this controls the active weapon and it's location
    //-----------------------------------------------//

    //defining current weapon will probably change down the track to be more resourceful.
    public GameObject currentWeapon;

    //this could be inherited from the weapon itself, depending on the weapons added, this might be the best idea.
    [Header("orignal pos")]
    public Vector3 originalPos;
    public Vector3 originalRot;
    [Header("Ads pos")]
    public Vector3 AdsPos;
    public Vector3 AdsRot;

    [Header("Ads Speed")]
    public float adsSpeed;


    [Header("Weapon Settings")]
    public GameObject BarrelPos;
    public Magazine loadedMag;

    void Start()
    {
        currentWeapon = this.gameObject;


        currentWeapon.transform.localPosition = originalPos;
        currentWeapon.transform.localRotation = Quaternion.Euler(originalRot);
    }

    private void AimDownSights()
	{
		if(Input.GetButton("Fire2"))
		{
			currentWeapon.transform.localPosition = Vector3.Lerp(currentWeapon.transform.localPosition, AdsPos, adsSpeed*Time.deltaTime);
            currentWeapon.transform.localRotation = Quaternion.Lerp(currentWeapon.transform.localRotation, Quaternion.Euler(AdsRot), adsSpeed*Time.deltaTime);

		}else{

			currentWeapon.transform.localPosition = Vector3.Slerp(currentWeapon.transform.localPosition, originalPos, adsSpeed*Time.deltaTime);
            currentWeapon.transform.localRotation = Quaternion.Lerp(currentWeapon.transform.localRotation, Quaternion.Euler(AdsRot), adsSpeed*Time.deltaTime);
		}
	}

    // Update is called once per frame
    void LateUpdate()
    {   
        AimDownSights();
    }

    // IEnumerator Ads()
    // {
    //     float startTime = Time.time;

    //     while(Time.time < startTime + adsSpeed)
    //     {
    //         currentWeapon.transform.localPosition = Vector3.Lerp(originalPos, AdsPos, adsSpeed*Time.deltaTime);
    //         yield return null;
    //     }
    // }
}
