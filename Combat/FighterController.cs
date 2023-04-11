using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class FighterController : MonoBehaviour, IAction
    {
        private Transform _target;
        private MovementController _movementController;
        private ActionScheduler _actionScheduler;
        private Animator _animator;
        private const float WeaponRange = 2f;
        private const float TimeBetweenAttacks = 1.3f;
        private float _timeSinceLastAttack;

        public void Start()
        {
            _actionScheduler = GetComponent<ActionScheduler>();
            _animator = GetComponent<Animator>();
            _movementController = GetComponent<MovementController>();
        }

        public void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;
            
            if (!HasTarget()) return;
            
            _movementController.MoveTo(_target.position);

            if (Vector3.Distance(transform.position, _target.position) > WeaponRange) return;
            
            _movementController.Cancel();
            
            if (_timeSinceLastAttack >= TimeBetweenAttacks)
            {
                transform.LookAt(_target);
                _animator.SetTrigger("attack");
                _timeSinceLastAttack = 0;
            }
        }

        public void StartAttackAction(CombatTarget combatTarget)
        {
            _actionScheduler.StartAction(this);
            _target = combatTarget.transform;
        }

        private bool HasTarget()
        {
            return _target != null;
        }

        public void Cancel()
        {
            _target = null;
        }

        // Animation Event
        public void Hit()
        {
            if (_target == null) return;
            
            Enemy enemy = _target.GetComponent<Enemy>();
            enemy.TakeDamage(5f);
            
            Cancel();
        }
    }
}