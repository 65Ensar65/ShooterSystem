using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : Base,IInteract
{
    ObjectType objectType = ObjectType.Rope;

    public void GetInteract(ObjectType _objectType, Transform _transform, Action<ObjectType, Transform> _action)
    {
        switch (_objectType)
        {
            case ObjectType.Bullet:
                GameManager.Instance.FakeRope.Remove(transform);
                Destroy(gameObject);
                _action.Invoke(objectType, transform);
                break;
            default:
                break;
        }
    }
}
