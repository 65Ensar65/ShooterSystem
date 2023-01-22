using Obi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealRopeController : Base,IInteract
{
    ObjectType type = ObjectType.RealRope;
    [SerializeField] Transform Build;
    public void GetInteract(ObjectType _objectType, Transform _transform, Action<ObjectType, Transform> _action)
    {
        switch (_objectType)
        {
            case ObjectType.Bullet:
                Destroy(GetComponent<ObiParticleAttachment>());
                e_buildController.GetBuildControl();
                _action.Invoke(type, transform);
                break;
            default:
                break;
        }
    }
}
