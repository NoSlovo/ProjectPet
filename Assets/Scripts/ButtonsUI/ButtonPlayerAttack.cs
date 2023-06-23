using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonPlayerAttack : MonoBehaviour
{
   [SerializeField] private Player _player;

   private Button _buttonUI;

   private void Start()
   {
      _buttonUI = GetComponent<Button>();
      _buttonUI.onClick.AddListener(_player.Atack);
   }
}
