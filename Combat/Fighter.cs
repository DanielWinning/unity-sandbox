using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        private Transform _target;
        private MovementController _movementController;
        const float WeaponRange = 2f;

        public void Start()
        {
            _movementController = GetComponent<MovementController>();
        }

        public void Update()
        {
            if (HasTarget())
            {
                _movementController.MoveTo(_target.position);
                
                if (Vector3.Distance(transform.position, _target.position) <= WeaponRange)
                {
                    _movementController.Stop();
                    ClearTarget();
                }
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            _target = combatTarget.transform;
        }

        public bool HasTarget()
        {
            return _target != null;
        }

        public void ClearTarget()
        {
            _target = null;
        }
    }
}