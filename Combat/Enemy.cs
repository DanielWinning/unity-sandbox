using RPG.Animation;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Combat
{
    [RequireComponent(typeof(PlayerAnimation), typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private PlayerAnimation _playerAnimation;
        public float maxHealth;
        private float _currentHealth;
        public bool isDead = false;

        public void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _playerAnimation = GetComponent<PlayerAnimation>();
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth = Mathf.Max(_currentHealth - damage, 0);

            if (_currentHealth == 0)
            {
                _playerAnimation.PlayDeathAnimation();
                isDead = true;
                _playerAnimation.enabled = false;
                _navMeshAgent.enabled = false;
            }
        }

        public void RestoreHealth(float healthRestored)
        {
            _currentHealth = Mathf.Min(_currentHealth + healthRestored, maxHealth);
        }
    }
}