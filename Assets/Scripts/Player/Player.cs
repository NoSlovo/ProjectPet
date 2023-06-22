using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AnimatorPlayer))]
public class Player : MonoBehaviour
{
    [SerializeField] private ButtonHandler _buttonHandler;
    private CharacterController _character;
    private AnimatorPlayer _animatorPlayer;
    private float _spead = 0.05f;

    private void Start()
    {
        _character = GetComponent<CharacterController>();
        _animatorPlayer = GetComponent<AnimatorPlayer>();
    }

    private void Update() => Move(_buttonHandler.Direction);
    
    private void Move(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            _animatorPlayer.StopMove();
            return;
        }

        var _characterDirection = new Vector3(direction.x, 0, direction.y);
        transform.forward = _characterDirection;
        _character.Move(_characterDirection * _spead);
        _animatorPlayer.PlayMove();
    }
}