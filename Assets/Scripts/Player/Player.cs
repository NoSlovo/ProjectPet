using System;
using RaceStats.RaceType;
using UnityEngine;

[RequireComponent(typeof(CharacterController),(typeof(СharacterAnimator)))]
public class Player : MonoBehaviour
{
    [SerializeField] private ButtonHandler _buttonHandler;
    
    private CharacterController _character;
    private СharacterAnimator _сharacterAnimator;
    private CharacterStats _characterStats;
    private float _velocity;
    
    public Stats Stats { get; private set; }

    private void Awake()
    {
        _characterStats = new CharacterStats(this, RaceType.Wars);
    }

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
        _velocity = new Vector2(direction.x,direction.y).magnitude * Stats.Spead;
        transform.forward = _characterDirection;
        _character.Move(_characterDirection * (Stats.Spead * Time.deltaTime));
        _сharacterAnimator.PlayMove(_velocity);
    }

    public void Atack()
    {
        _сharacterAnimator.Attack();
    }

    public void GetStats(Stats characterStats)
    {
        Stats = characterStats;
    }
}