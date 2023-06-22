using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorPlayer : MonoBehaviour
{
  [SerializeField] private Animator _animator;
  
   private readonly int _iMove = Animator.StringToHash("IMove");
   
   private void Start()=> _animator.GetComponent<Animator>();

   public void PlayMove() => _animator.SetBool(_iMove, true);
   public void StopMove() => _animator.SetBool(_iMove, false);
}
