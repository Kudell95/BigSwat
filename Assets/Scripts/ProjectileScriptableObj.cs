using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Projectile", menuName = "Weapons/Projectiles", order = 1)]
public class ProjectileScriptableObject : ScriptableObject 
{

	public enum category {Rifle, Pistol, Shrapnel, Other}

	public string Name;

	public category Type;

	public bool Explosive;

	public bool Tracer;

	public float Velocity;

	public bool Supersonic;

	public float recoilModifier;

	public GameObject Projectile;

	public GameObject WorldObj;

	public GameObject ShellCasing;

	public AudioClip Gunshot;


}
