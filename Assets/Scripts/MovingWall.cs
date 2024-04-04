using UnityEngine;

namespace MengQiLei
{
    public class MovingWall : MonoBehaviour
    {
        [SerializeField]private float speed = 2f;
        [SerializeField] private float moveDistantce = 8f;

        private Vector3 startPos;
        private Vector3 endPos;
        private bool movingToEnd = true; // Flag to track direction of movement

        void Start()
        {
            // Initialize start and end positions
            startPos = transform.position;
            endPos = new Vector3(startPos.x, startPos.y, startPos.z - moveDistantce);
        }

        void Update()
        {
            // Calculate the next position based on direction and speed
            Vector3 nextPos;
            if (movingToEnd) nextPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
            else nextPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

            // If wall reaches end position, switch direction
            if (transform.position.z <= endPos.z)
            {
                movingToEnd = false;
            }
            // If wall reaches start position, switch direction
            else if (transform.position.z >= startPos.z)
            {
                movingToEnd = true;
            }
        }
    }
}
