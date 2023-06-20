using System;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController _character;
    private float _spead = 0.05f;

    private void Start() => _character = GetComponent<CharacterController>();


    public void Move(Vector2 direction)
    {
        if (direction == Vector2.zero)
            return;
        
        var _characterDirection = new Vector3(direction.x, 0, direction.y);

        transform.forward = _characterDirection;
        _character.Move(_characterDirection * _spead);
    }
}