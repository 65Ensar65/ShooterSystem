using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivillianRunControl : Base, IRunnable
{
    private int _index;

    public Transform[] WayPoint;
    public float Speed;

    private void Update()
    {
        GetRunController();
    }
    public void GetRunController()
    {
        transform.position = Vector3.MoveTowards(transform.position, WayPoint[_index].position, Speed);
        transform.LookAt(WayPoint[_index].position);

        if (WayPoint[_index].position == transform.position)
        {
            _index++;
        }

        if (_index == WayPoint.Length)
        {
            _index = 0;
        }
    }
}