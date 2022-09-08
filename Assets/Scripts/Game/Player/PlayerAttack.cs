using System;
using Unity.Mathematics;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpownPointTransform;
        [SerializeField] private float _fireDelay = 0.3f;
        
        private Transform _cashedTransform;
        private float _timer;

        private void Awake()
        {
            _cashedTransform = transform;
        }

        private void Update()
        {
            if (CanAttack())
            {
                Attack();
            }

            TickTimer();
        }

        private void TickTimer()
        {
            _timer -= Time.deltaTime;
        }

        private bool CanAttack()
        {
            return Input.GetButton("Fire1") && _timer <= 0;
        }
        private void Attack()
        {
            Instantiate(_bulletPrefab, _bulletSpownPointTransform.position, _cashedTransform.rotation);
            _timer = _fireDelay;
        }
    }
}


