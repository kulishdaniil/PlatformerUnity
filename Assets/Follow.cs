using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Player;
    public float TargetDistance;
    public float AllowedDistance = 2;
    public GameObject Cam;
    public GameObject NPC;
    public float FollowSpeed;
    public RaycastHit Shot;

    void Update()
    {
        var dir = Cam.transform.position - transform.position;
        transform.LookAt(transform.position - dir);
        Vector3 v = new Vector3(Player.transform.position.x - 0.5f, 1.8f, Player.transform.position.z - 0.5f);
        transform.position = v;

        /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance=Shot.distance;
            if (TargetDistance >= AllowedDistance)
            {
                FollowSpeed = 0.1f;
                transform.position=Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, 1.8f, Player.transform.position.z), FollowSpeed);
            }
            else
            {
               FollowSpeed = 0;
            }
        }*/
    }
}
