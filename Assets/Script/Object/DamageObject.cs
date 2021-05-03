using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [Tooltip("오브젝트가 주는 데미지")] [SerializeField] private float damage;


    private void Start()
    {
        damage = 2;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Touch Player");
            other.GetComponent<Player>().GetDamage(damage);
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            float fallDamage = collision.relativeVelocity.magnitude;

            if (fallDamage > 20f)
            {
                Debug.Log("over 20");
                collision.gameObject.GetComponent<Player>().GetDamage(damage);
            }

        }
    }
}
