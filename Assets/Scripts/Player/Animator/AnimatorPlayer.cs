using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorPlayer : MonoBehaviour
{
  [SerializeField] private Animator _animator;
  
   private readonly int _iMove = Animator.StringToHash("IMove");
   private readonly int _attackOne = Animator.StringToHash("Attack1");
   private readonly int _attackTwo = Animator.StringToHash("Attack2");

   private int _attackNumber = 0;

   private void Start()=> _animator.GetComponent<Animator>();

   public void PlayMove() => _animator.SetBool(_iMove, true);
   public void StopMove() => _animator.SetBool(_iMove, false);

   public void Attack()
   {
       if (_animator.GetCurrentAnimatorStateInfo(1).IsName("Attack1"))
          return;
       
       if (_animator.GetCurrentAnimatorStateInfo(1).IsName("Attack2"))
           return;
       
    if (_attackNumber == 0)
    {
        _animator.Play(_attackOne,1);
        _attackNumber++;
    }
    else
    {
        _animator.Play(_attackTwo,1);
        _attackNumber--;
    }
   }
}
