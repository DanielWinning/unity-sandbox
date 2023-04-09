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
        private const float WeaponRange = 2f;

        public void Start()
        {
            _movementController = GetComponent<MovementController>();
            _actionScheduler = GetComponent<ActionScheduler>();
        }

        public void Update()
        {
            if (!HasTarget()) return;
            
            _movementController.MoveTo(_target.position);

            if (Vector3.Distance(transform.position, _target.position) >= WeaponRange) return;
            
            _movementController.Stop();
            ClearTarget();
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

        private void ClearTarget()
        {
            _target = null;
        }

        public void Cancel()
        {
            ClearTarget();
        }
    }
}