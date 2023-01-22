using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;
using Cinemachine;

public class PlayerShootController : IShootable
{
    private bool _ýsFree;
    public void GetShootController(Transform _sniper, Transform _bulletTarget, Transform _camera, GameObject _target, ObjectPool _objectPool, CinemachineVirtualCameraBase _virtualCamera, LayerMask layerMask)
    {

        if (Input.GetMouseButton(0))
        {
            _sniper.DOLocalMove(new Vector3(0, 0.355f, 0.426f), 0.5f);
            _sniper.gameObject.SetActive(false);
            _target.SetActive(true);
            _ýsFree = true;
        }

        else
        {
            if (_ýsFree)
            {
                _camera.DOLocalMoveZ(-0.7f, .25f).OnComplete(
                    delegate 
                    {
                        _camera.DOLocalMoveZ(-0.1f, .25f);
                        _sniper.gameObject.SetActive(true);
                        _target.SetActive(false);
                        _sniper.DOLocalMove(new Vector3(0.1f, 0.274f, 0.426f), 0.5f).SetEase(Ease.OutBack);
                    });

                _ýsFree = false;

                GameObject obj = _objectPool.ActivePoolObject(ObjectTag.Bullet, _bulletTarget);

                RaycastHit hit;

                if (Physics.Raycast(_bulletTarget.transform.position , _bulletTarget.transform.TransformDirection(_bulletTarget.transform.forward) ,out hit, Mathf.Infinity, layerMask) && GameManager.Instance.FakeRope.Count == 0)
                {
                    GameManager.Instance.BulletSpeed = 0.025f;
                    _virtualCamera.gameObject.SetActive(true);
                    _virtualCamera.transform.parent = null;
                    _virtualCamera.Follow = obj.transform;
                    _virtualCamera.LookAt = obj.transform;
                    Debug.DrawRay(_bulletTarget.transform.position, _bulletTarget.transform.TransformDirection(_bulletTarget.transform.forward) * hit.distance, Color.green);
                }
            }
        }
    }
}
