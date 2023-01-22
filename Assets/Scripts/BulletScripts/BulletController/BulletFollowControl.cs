using Cinemachine;
using UnityEngine;

public class BulletFollowControl : IFollowble
{
    public void GetFollowControl(float _followSpeed, Transform _bullet)
    {
        _bullet.Translate(_bullet.forward * _followSpeed, Space.World);
    }
}
