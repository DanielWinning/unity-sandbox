using RPG.Combat;
using RPG.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Control
{
    public class EnemyController : MonoBehaviour
    {
        private Enemy _enemy;
        private GameObject _player;
        private MovementController _movementController;
        public float detectionRange = 10f;

        public void Start()
        {
            _enemy = GetComponent<Enemy>();
            _movementController = GetComponent<MovementController>();
            _player = GameObject.FindWithTag("Player");
        }
        
        public void Update()
        {
            if (_enemy.isDead) return;
            
            float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);

            if (distanceToPlayer > detectionRange || distanceToPlayer <= 2.0f) return;
            
            _movementController.MoveTo(_player.transform.position);
            GetComponent<Animator>().SetFloat("forwardSpeed", transform.InverseTransformDirection(GetComponent<NavMeshAgent>().velocity).z);
        }
    }
}