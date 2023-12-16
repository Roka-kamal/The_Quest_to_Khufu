using System.Collections;
using UnityEngine;

public class RandomMovingEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float wallDetectionDistance = 0.2f;
    private bool isFacingRight = true;

    void Start()
    {
        StartCoroutine(WallWalk());
    }

    IEnumerator WallWalk()
    {
        while (true)
        {
            // Move in the current direction
            MoveWithCheck(isFacingRight ? Vector2.right : Vector2.left);

            // Wait for a short time
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void MoveWithCheck(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, wallDetectionDistance);
        if (hit.collider != null)
        {
            // If facing a wall, flip direction
            Flip();
        }
        else
        {
            // Move in the specified direction
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * direction.x, GetComponent<Rigidbody2D>().velocity.y);

            // Update the facing direction based on the movement
            if (direction.x > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (direction.x < 0 && isFacingRight)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        // Flip the enemy to the other side
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
