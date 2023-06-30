using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(СharacterAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private ButtonHandler _buttonHandler;
    
    private CharacterController _character;
    private СharacterAnimator _сharacterAnimator;
    private float _spead = 0.05f;

    private void Start()
    {
        _character = GetComponent<CharacterController>();
        _сharacterAnimator = GetComponent<СharacterAnimator>();
    }

    private void Update() => Move(_buttonHandler.Direction);
    
    private void Move(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            _сharacterAnimator.StopMove();
            return;
        }

        var _characterDirection = new Vector3(direction.x, 0, direction.y);
        transform.forward = _characterDirection;
        _character.Move(_characterDirection * _spead);
        _сharacterAnimator.PlayMove();
    }

    public void Atack()
    {
        _сharacterAnimator.Attack();
    }
}