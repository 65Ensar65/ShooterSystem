using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [HideInInspector] public Rigidbody e_rigidbody;
    [HideInInspector] public BoxCollider e_collider;
    [HideInInspector] public Animator e_animator;
    [HideInInspector] public SphereCollider e_sphereCollider;
    [HideInInspector] public MeshRenderer e_meshRenderer;
    [HideInInspector] public Joystick e_joystick;
    [HideInInspector] public ObjectPool e_objectPool;
    [HideInInspector] public BuildController e_buildController;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        e_rigidbody = (GetComponent<Rigidbody>()) ? GetComponent<Rigidbody>() : null;
        e_collider = (GetComponent<BoxCollider>()) ? GetComponent<BoxCollider>() : null;
        e_animator = (GetComponent<Animator>()) ? GetComponent<Animator>() : null;
        e_meshRenderer = GetComponent<MeshRenderer>() ? GetComponent<MeshRenderer>() : null;
        e_sphereCollider = GetComponent<SphereCollider>() ? GetComponent<SphereCollider>() : null;
        e_joystick = (FindObjectOfType<Joystick>()) ? FindObjectOfType<Joystick>() : null;
        e_objectPool = (FindObjectOfType<ObjectPool>()) ? FindObjectOfType<ObjectPool>() : null;
        e_buildController = (FindObjectOfType<BuildController>()) ? FindObjectOfType<BuildController>() : null;
    }
}
