using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingleton<T> : Base where T : BaseSingleton<T>
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
            }

            return _instance;
        }
    }
}
