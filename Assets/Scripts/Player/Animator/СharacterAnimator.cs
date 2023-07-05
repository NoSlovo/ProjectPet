using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

[RequireComponent(typeof(Animator))]
public class СharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int _iMove = Animator.StringToHash("IMove");
    private readonly int _speed = Animator.StringToHash("Speed");
    private static readonly int _attackOne = Animator.StringToHash("Attack1");
    private static readonly int _attackTwo = Animator.StringToHash("Attack2");

    private Stopwatch _lastCallTime = new ();

    private float _delay = 3000f;
    private float _defaultValue = 0;

    private List<int> _attackHash = new ()
    {
        _attackOne, 
        _attackTwo
    };

    private int _attackNumber = 0;


    private void Start()
    {
        _animator.GetComponent<Animator>();
        _lastCallTime.Start();
    }

    public void PlayMove(float velocity )
    {
        
        _animator.SetFloat(_speed,velocity);
        _animator.SetBool(_iMove, true);
    }

    public void StopMove()
    {
        _animator.SetBool(_iMove, false);
        _animator.SetFloat(_speed,_defaultValue);
    }

    public void Attack()
    {
        if (CheckingAnimationPlayback())
            return;
        
        ResetAttack();

        _animator.Play(_attackHash[_attackNumber],1);
        _attackNumber++;
    }


    private bool CheckingAnimationPlayback()
    {
        if (_animator.GetCurrentAnimatorStateInfo(1).IsName("Attack1"))
            return true;

        if (_animator.GetCurrentAnimatorStateInfo(1).IsName("Attack2"))
            return true;

        return false;
    }

    private void ResetAttack()
    {
        float seconds = _lastCallTime.ElapsedMilliseconds;
        
        if (_attackNumber >= _attackHash.Count || seconds > _delay )
        {
            _attackNumber = 0;
            _lastCallTime.Reset();
            _lastCallTime.Start();
        }
    }
}