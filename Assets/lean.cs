using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lean : MonoBehaviour
{
    public Vector3 leanPos;
    public Vector3 LeanRot;
    private Vector3 defaultpos;    
    public float leanspeed;
    bool reset = false;
    // Start is called before the first frame update
    void Start()
    {
        defaultpos = transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetButton("LeanRight"))
        {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition,  leanPos, leanspeed * Time.deltaTime);
            this.transform.localRotation =  Quaternion.Lerp(this.transform.localRotation, Quaternion.Euler(LeanRot), leanspeed*Time.deltaTime); // Quaternion.Euler(LeanRot); 
            reset = false;
        }
        if(Input.GetButtonUp("LeanRight"))
        {
            reset = true; //reset flag so
            // transform.localPosition = new Vector3(0,0,0);
            // transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
            //  this.transform.localPosition = Vector3.Lerp(this.transform.localPosition,  new Vector3(0,0,0), leanspeed * Time.deltaTime); 
            // this.transform.localRotation = Quaternion.Lerp(this.transform.localRotation, Quaternion.Euler(new Vector3(0,0,0)), leanspeed*Time.deltaTime);
        }

        if(Input.GetButton("LeanLeft"))
        {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition,  -leanPos, leanspeed * Time.deltaTime);
            this.transform.localRotation =  Quaternion.Lerp(this.transform.localRotation, Quaternion.Euler(-LeanRot), leanspeed*Time.deltaTime); // Quaternion.Euler(LeanRot); 
            reset = false;
        }

        if(Input.GetButtonUp("LeanLeft"))
        {
            reset = true;
        }


        if(reset)
        {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition,  new Vector3(0,0,0), leanspeed * Time.deltaTime); 
            this.transform.localRotation = Quaternion.Lerp(this.transform.localRotation, Quaternion.Euler(new Vector3(0,0,0)), leanspeed*Time.deltaTime);
        }
        // 
    }
}
