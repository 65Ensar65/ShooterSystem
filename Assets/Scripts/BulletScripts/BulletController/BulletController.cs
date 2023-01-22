using DG.Tweening;
using Obi;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : Base,IBullet
{
    private ObjectType objectType = ObjectType.Bullet;

    private IFollowble _followble;

    private void Start()
    {
        _followble = new BulletFollowControl();
    }
    void Update()
    {
        GetBulletControl();
    }

    public void GetBulletControl()
    {
        _followble.GetFollowControl(GameManager.Instance.BulletSpeed, transform);
        Invoke("GetSpeedCalculate", 2);
    }
    void GetSpeedCalculate()
    {
        GameManager.Instance.BulletSpeed = .25f;
    }

    public void GetSelectFuncObject(ObjectType _objectType, Transform _transform)
    {
        switch (_objectType)
        {
            case ObjectType.Rope:
                Debug.Log("Shoot the rope");
                e_objectPool.ReturnPoolObject(ObjectTag.Bullet, gameObject);
                break;

            case ObjectType.RealRope:
                GameManager.Instance.cinemachine.gameObject.SetActive(false);
                GameManager.Instance.Camera.transform.DOLocalMove(new Vector3(-0.06f, 0.55f, 1.05f), 1);
                GameManager.Instance.Camera.transform.DOLocalRotate(new Vector3(0, 20, 0), 1);
                e_objectPool.ReturnPoolObject(ObjectTag.Bullet, gameObject);
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteract>()?.GetInteract(objectType, transform, GetSelectFuncObject);
    }
}

