using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;

    public Vector2 Direction { get; private set;}

    public void Update() => Direction = _joystick.Direction;
}
