using Cinemachine;
using System;
using UnityEngine;

public interface ISwipeble
{
    void SwipeController(Joystick _joystick, float _swipeSpeed, float _swipeHorizontalClamp, float _swipeVerticalClamp, float _smoothSpeed, Transform _transform);
}

public interface IShootable
{
    void GetShootController(Transform _sniper, Transform _bulletTarget, Transform _camera, GameObject _target, ObjectPool _objectPool, CinemachineVirtualCameraBase _virtualCamera, LayerMask layerMask);
}

public interface IInteract
{
    void GetInteract(ObjectType _objectType, Transform _transform , Action<ObjectType,Transform> _action);
}
public enum ObjectType
{
    Bullet,
    Rope,
    RealRope
}
