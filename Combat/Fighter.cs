using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        private Transform _target;
        private MovementController _movementController;
        private float _weaponRange = 3.5f;

        public void Start()
        {
            _movementController = GetComponent<MovementController>();
        }

        public void Update()
        {
            if (_target != null)
            {
                _movementController.MoveTo(_target.position);
                
                if (Vector3.Distance(transform.position, _target.position) <= _weaponRange)
                {
                    _movementController.Stop();
                    _target = null;
                }
            }
        }
        
        public void Attack(CombatTarget combatTarget)
        {
            _target = combatTarget.transform;
        }
    }
}