using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class BoxVacuum : MonoBehaviour
{
    [SerializeField] public float GRAVITY_PULL = .78f;
    public static float m_GravityX = 1f;
    public static float m_GravityY = 1f;

    void Awake()
    {
        m_GravityX = GetComponent<BoxCollider2D>().size.x;
        m_GravityY = GetComponent<BoxCollider2D>().size.y;
    }
    /// <summary>
    /// Attract objects towards an area when they come within the bounds of a collider.
    /// This function is on the physics timer so it won't necessarily run every frame.
    /// </summary>
    /// <param name="other">Any object within reach of gravity's collider</param>

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.attachedRigidbody)
        {
            float gravityIntensityX = Vector3.Distance(transform.position, other.transform.position) / m_GravityX;
            float gravityIntensityY = Vector3.Distance(transform.position, other.transform.position) / m_GravityY;

            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensityX * other.attachedRigidbody.mass * GRAVITY_PULL * Time.smoothDeltaTime);
            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensityY * other.attachedRigidbody.mass * GRAVITY_PULL * Time.smoothDeltaTime);

            Debug.DrawRay(other.transform.position, transform.position - other.transform.position);
        }
    }
}
