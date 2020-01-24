using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 40.0f;

    public bool flying = false;
    public float drag = 10.0f;

    private Vector3 moveVec;
    private Vector3 forward;
    public Vector3 velocity { get; set; }
    private bool grounded = false;

    private CharacterController controller;

    void Start()
    {
        velocity = Vector3.zero;
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Vector3 forcesVec = Vector3.zero;
        forcesVec += this.Gravity();
        forcesVec += this.Forces();

        if (forcesVec == Vector3.zero)
        {
            forcesVec = Vector3.up * 0.0001f;
        }

        //if(forcesVec != Vector3.zero)
        //{
        var flags = controller.Move(forcesVec * Time.fixedDeltaTime);
        grounded = (flags & CollisionFlags.CollidedBelow) != 0;
        //}
    }

    public Vector3 Gravity()
    {
        Vector3 grav = Vector3.zero;
        if (!grounded)
        {
            grav = new Vector3(0.0f, -5.0f, 0.0f);
        }     
        if (flying && transform.position.y <= 0.25f)
        {
            grav = Vector3.zero;
        }
        return grav;
    }

    public Vector3 Forces()
    {
        Vector3 vec = Vector3.zero;

        if (velocity != Vector3.zero)
        {
            vec = velocity;

            if (velocity.magnitude > 0.01f)
            {
                velocity -= (velocity * drag * Time.fixedDeltaTime);
            } else
            {
                velocity = Vector3.zero;
            }
        }

        return vec;
    }

    public void AddForce(Vector3 force)
    {
        velocity += force;
    }

    public Vector3 GetForce()
    {
        return velocity;
    }
}
