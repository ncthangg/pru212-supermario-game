using UnityEngine;

public static class Extensions
{
    private static LayerMask layerMask = LayerMask.GetMask("Ground");

    // Checks if the rigidbody is colliding with an object in a given direction.
    // For example, if you want to check if the player is touching the ground,
    // you can pass Vector2.down. If you want to check if the player is running
    // into a wall, you can pass Vector2.right or Vector2.left.
    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
    {
        if (rigidbody.isKinematic)
        {
            return false;
        }

        float radius = 0.1f;
        float distance = 0.8f;

        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction, distance, layerMask);
        Debug.DrawRay(rigidbody.position, direction * distance, hit ? Color.green : Color.red);
        return hit.collider != null && hit.rigidbody != rigidbody;

    }

    // Checks if the transform is facing another transform in a given direction.
    // For example, if you want to check if the player stomps on an enemy, you
    // would pass the player transform, the enemy transform, and Vector2.down.
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
    }

}
