using UnityEngine;

namespace RPG.Environment
{
    public class Clouds : MonoBehaviour
    {
        public float speedModifier = 1f;
        
        public void Update()
        {
            transform.Rotate(speedModifier * (Vector3.up * Time.deltaTime));
        }
    }
}