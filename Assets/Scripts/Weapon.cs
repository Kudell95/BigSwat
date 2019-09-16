using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public ProjectileScriptableObject Calibre;
	public ParticleSystem MuzzleFlash;
	private Animator anim;
	public int MagazineSize;
	public int CurrentAmmo;

	private Vector3 OriginalPos;
	public Vector3 AimPos;

	public float ADS_speed = 8;

	public GameObject Player;

	public AudioClip[] ReloadSounds;

	public GameObject Hands;

	public Transform barrelPos;

	//this script handles both the weapon firing and the animations relating to the gun

	private void AimDownSights()
	{
		if(Input.GetButton("Fire2"))
		{
			Hands.transform.localPosition = Vector3.Lerp(Hands.transform.localPosition, AimPos, Time.deltaTime * ADS_speed);

		}else{

			Hands.transform.localPosition = Vector3.Lerp(Hands.transform.localPosition, OriginalPos, Time.deltaTime * ADS_speed);
		}
	}

	public void Shoot(){
		GameObject bullet;
		bullet = Instantiate(Calibre.Projectile, barrelPos.position, barrelPos.rotation);
		//bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Calibre.Velocity * 100, ForceMode.Acceleration);
        bullet.GetComponent<Projectile>().Bullet = Calibre;
		

	}

	// Use this for initialization
	void Start () {
		// anim = Hands.GetComponent<Animator>();
		OriginalPos = Hands.transform.localPosition;

		// Player = GameObject.Find("FirstPersonCharacter");
	}


	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			// anim.CrossFadeInFixedTime("Hands|M4A1_Fire",0.01f);
			// GetComponent<Animator>().CrossFadeInFixedTime("Hands|M4A1_Fire", 0.01f);
			Player.GetComponent<Pure_FPP_Camera>().Recoil();
			// Hands.GetComponent<AudioSource>().PlayOneShot(Calibre.Gunshot,1f);
			// MuzzleFlash.Play();
			Shoot();

		}else if (Input.GetKeyDown(KeyCode.R)){
			// anim.CrossFadeInFixedTime("Hands|M4A1_Reload",0.01f);
			StartCoroutine(Reloading());

		}
		// else if(Input.GetKeyDown(KeyCode.G)){

		// 	StartCoroutine(Grenade());
		// }

		

			// AimDownSights();
		

	}


	//  private IEnumerator Grenade(){
	// 	 anim.CrossFadeInFixedTime("Hands|M4A1 Take Out",0.01f);
	// 	 yield return new WaitForSeconds(0.5f);
	//  }

	 private IEnumerator Reloading(){
		 yield return new WaitForSeconds(0.5f);
		// Hands.GetComponent<AudioSource>().PlayOneShot(ReloadSounds[0],0.5f);
		 yield return new WaitForSeconds(1.72f);
		// Hands.GetComponent<AudioSource>().PlayOneShot(ReloadSounds[1],0.5f);
	 }



}
