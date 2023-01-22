using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRaySystem : Base
{
    public LayerMask LayerMask;
    void Update()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, transform.TransformDirection(transform.forward), out hit, Mathf.Infinity, LayerMask);
        Debug.Log("Get Rope Hit");
        Debug.DrawRay(transform.position, transform.TransformDirection(transform.forward) * hit.distance, Color.green);
        
    }
}
