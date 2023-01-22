using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cinemachine;
using DG.Tweening;
using UnityEngine.UIElements;

public class PlayerController : Base
{
    private ISwipeble _swipeble;
    private IShootable _shootable;


    [Title("Player Swipe Values")]
    [SerializeField] float SwipeSpeed;
    [SerializeField] float SwipeHorizontalClamp;
    [SerializeField] float SwipeVerticalClamp;
    [Range(0, 1)]
    [SerializeField] float Smoothspeed;

    [Title("Player Shooting Values")]
    [SerializeField] GameObject Target;
    [SerializeField] Transform Sniper;
    [SerializeField] Transform BulletTarget;
    [SerializeField] Transform Camera;
    [SerializeField] LayerMask LayerMask;

    void Start()
    {
        _shootable = new PlayerShootController();
        _swipeble = new PlayerSwipe();
    }

    void FixedUpdate()
    {
        _swipeble.SwipeController(e_joystick, SwipeSpeed, SwipeHorizontalClamp,SwipeVerticalClamp, Smoothspeed, transform);
        _shootable.GetShootController(Sniper, BulletTarget, Camera, Target, e_objectPool,GameManager.Instance.cinemachine,LayerMask);
    }
}
