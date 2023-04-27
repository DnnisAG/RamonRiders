using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] float force = 10f; // The amount of force to apply to the object when hit
    [SerializeField] float lifetime = 0.5f; // The lifetime of the object in seconds

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController gameController = FindObjectOfType<GameController>();
            if (gameController != null)
            {
                gameController.LoseLife();
            }
            Vector3 direction = collision.contacts[0].point - transform.position;
            rb.AddForce(direction.normalized * force, ForceMode.Impulse);
            Destroy(gameObject, lifetime);
        }
    }
}
