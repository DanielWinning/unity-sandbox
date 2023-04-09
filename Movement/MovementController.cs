using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class MovementController : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
    
        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }
        private void Update()
        {
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 currentVelocity = _navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(currentVelocity);
            _animator.SetFloat("forwardSpeed", localVelocity.z);
        }

        public void MoveTo(Vector3 point)
        {
            _navMeshAgent.destination = point;
            _navMeshAgent.isStopped = false;
        }

        public void Stop()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}
