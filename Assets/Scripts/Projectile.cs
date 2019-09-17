using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{


    public ProjectileScriptableObject Bullet;
    public float range;
    public float gravity = 0.8f;

    private bool hasBeenHit = false;

    public GameObject gun;

    private GameObject potentialTarget;
    public Vector3 roundVelocity;

    private TrailRenderer trail;

    public float MaxRicochetAngle = 75;

    public float CurrentVelocity;

    public GameObject[] ParticleEffects;

    public float rand;
    
    void Awake()
    {
        rand = Random.Range(1f, 3f);
    }


    IEnumerator Start()
    {
        trail = GetComponent<TrailRenderer>();
        Vector3 vel = transform.forward * Bullet.Velocity; // calculate velocity vector
        Vector3 originalVel = vel;
        Vector3 pos = transform.position;
        CurrentVelocity = vel.magnitude;
        //Physics.IgnoreCollision(this.GetComponent<Collider>(), gun.GetComponent<Collider>());
        float dist = 0; // initialize distance travelled
        while (dist < range)
        {
            yield return null; // let Unity free till next frame
            vel.y -= gravity * Time.deltaTime; // apply gravity
            Vector3 newPos = pos + vel * Time.deltaTime; // calculate current position
            float thisDist = Vector3.Distance(pos, newPos); // get the distance since last frame
            dist += thisDist; // update total distance
                              // check collision

            
            //Debug.Log(CurrentVelocity);
            RaycastHit hit;
            //Debug.DrawRay(pos, newPos, Color.red);
            if (Physics.Linecast(pos, newPos, out hit))
            { // if something hit...


                switch (hit.transform.tag)
                {
                    case "Penetrable":
                        // object is penetrable
                        // Instantiate(hit.transform.gameObject.GetComponent<Wall>().particleEffects, hit.point, Quaternion.LookRotation(hit.normal));
                        gravity = gravity * hit.transform.gameObject.GetComponent<Wall>().wallVelocityChange;
                        vel = vel / 1.2f;
                        Debug.Log(vel.magnitude);
                        if(vel.magnitude < 100)
                        {
                            Destroy(gameObject);
                        }
                        CurrentVelocity = vel.magnitude;
                        hasBeenHit = true;
                        print("Penetrating " + hit.transform.name);
                        break;
                    case "Terrain":
                        // hit the ground: delete bullet (coroutine dies too)
                        Destroy(gameObject);
                        break;
                    default:
                        // other objects - bounce off:
                        
                        Debug.Log(rand);
                        if (!hasBeenHit && Vector3.Angle(vel, -hit.normal) > MaxRicochetAngle && rand > 2)
                        {

                            Debug.Log(Vector3.Angle(vel, -hit.normal));
                            vel = Vector3.Reflect(vel, hit.normal); // reflect velocity
                            thisDist -= hit.distance; // calculate distance from surface
                                                      // find new position after bouncing:
                            newPos = hit.point + thisDist * vel.normalized;
                        }
                        else
                        {
                            // Instantiate(ParticleEffects[0], hit.point, Quaternion.LookRotation(hit.normal));
                            //hitTarget
                            Destroy(gameObject);
                        }
                        break;
                }
            }
            transform.position = pos = newPos; // update position
            transform.forward = vel; // align bullet to the movement direction
        }
        // shot ended because it's out of range
        Destroy(gameObject); // bullet suicides
    }

    


    void OnDestroy()
    {
        transform.GetChild(0).transform.parent = null;
        trail.autodestruct = true;
    }

}