using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private void LateUpdate()
        {
            MoveCamera();
        }

        private void MoveCamera()
        {
            transform.position = new Vector3(
                target.position.x, 
                target.position.y + 7.5f, 
                target.position.z - 6.5f
            );
        }
    }
}