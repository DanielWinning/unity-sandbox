using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class MovementController : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Animator _animator;
    
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }
        private void Update()
        {
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 currentVelocity = _agent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(currentVelocity);
            _animator.SetFloat("forwardSpeed", localVelocity.z);
        }

        public void MoveTo(Vector3 point)
        {
            _agent.destination = point;
        }
    }
}
