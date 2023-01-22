using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using Cinemachine;

public class GameManager : BaseSingleton<GameManager>
{
    [Title("Rope Values")]
    public List<Transform> FakeRope = new List<Transform>();

    [Title("Bullet Values")]
    public float BulletSpeed;

    [Title("Camera Values")]
    public Transform Camera;
    public CinemachineVirtualCameraBase cinemachine;
}
