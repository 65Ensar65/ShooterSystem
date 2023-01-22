using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwipe : ISwipeble
{
    public void SwipeController(Joystick _joystick, float _swipeSpeed, float _swipeHorizontalClamp,float _swipeVerticalClamp ,float _smoothSpeed, Transform _transform)
    {
        if (_joystick.Horizontal != 0 && _joystick.Vertical != 0)
        {
            float HorizontalAxis = _joystick.Horizontal;
            float VerticalAxis = _joystick.Vertical;

            _transform.rotation = Quaternion.Slerp(_transform.rotation, Quaternion.Euler(Mathf.Clamp(_transform.rotation.x + (-VerticalAxis * _swipeSpeed * Time.deltaTime), -_swipeVerticalClamp, _swipeVerticalClamp),
                                                                             Mathf.Clamp(_transform.rotation.y + (HorizontalAxis * _swipeSpeed * Time.deltaTime), -_swipeHorizontalClamp, _swipeHorizontalClamp),
                                                                                         _transform.rotation.z), _smoothSpeed);
        }
    }
}
