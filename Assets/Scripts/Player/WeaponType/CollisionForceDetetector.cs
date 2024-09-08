using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionForceDetetector : MonoBehaviour
{
    public float impactForceThreshold = 10f; // A threshold to determine if the collision was strong enough.

    private void OnCollisionEnter(Collision collision)
    {
        // Get the relative velocity between the two objects
        Vector3 relativeVelocity = collision.relativeVelocity;

        // Calculate the force based on the mass of the object and the relative velocity
        Rigidbody rb = collision.rigidbody;

        if (rb != null)
        {
            // Force = mass * acceleration (here, velocity change)
            float impactForce = rb.mass * relativeVelocity.magnitude;

            Debug.Log($"Impact Force: {impactForce}");

            // Optional: Check if the impact exceeds a certain threshold
            if (impactForce > impactForceThreshold)
            {
                Debug.Log("Strong collision detected!");
                if (collision.transform.GetComponent<EnemyMovement>() != null)
                {
                    collision.transform.GetComponent<EnemyMovement>().StunEnemy();
                }
            }
        }
    }
}
