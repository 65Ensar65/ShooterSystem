using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFollowble
{
    void GetFollowControl(float _followSpeed , Transform _bullet);
}

public interface IBullet
{
    void GetBulletControl();
    void GetSelectFuncObject(ObjectType _objectType, Transform _transform);
}