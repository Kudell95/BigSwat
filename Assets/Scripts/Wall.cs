using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public enum WallType { Wood, Brick, Plaster, Metal, Stone};

    public WallType type;
    public float wallVelocityChange;
    public float velocityDeduction;

    public GameObject particleEffects;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
