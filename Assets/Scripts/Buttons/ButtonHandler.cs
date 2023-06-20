using System;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Player _player;

    private void Update()
    {
        _player.Move(_joystick.Direction);
    }
}
