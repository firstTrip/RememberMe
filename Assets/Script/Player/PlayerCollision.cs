using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Layers :")]
    [Tooltip("Wall 판별")] [SerializeField] private LayerMask wallLayer;
    [Tooltip("Ground 판별")] [SerializeField] private LayerMask groundLayer;

    [Space]

    [Header("Collision :")]
    [Tooltip("Collision 크기 :")] [SerializeField] private float CollisionRadius = 0.15f;
    [Tooltip("offset :")] [SerializeField] Vector3 BottomOffset, rightOffset, leftOffset;

    [Space]

    public bool OnGround;
    public bool OnWall;

    // Update is called once per frame
    void Update()
    {
        OnGround = Physics2D.OverlapCircle(transform.position + BottomOffset, CollisionRadius, groundLayer);
        OnWall = Physics2D.OverlapCircle(transform.position + rightOffset, CollisionRadius, wallLayer)
            || Physics2D.OverlapCircle(transform.position + leftOffset, CollisionRadius, wallLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + BottomOffset, CollisionRadius);
        Gizmos.DrawWireSphere(transform.position + rightOffset, CollisionRadius);
        Gizmos.DrawWireSphere(transform.position + leftOffset, CollisionRadius);
    }
}
