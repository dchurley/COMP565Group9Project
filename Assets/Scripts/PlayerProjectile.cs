using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject go;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsVisible())
        {
            // Destroy the projectile
            Destroy(gameObject);
        }
    }

    private bool IsVisible()
    {
        // Get the screen boundaries
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);

        // Check if the projectile is within the viewport
        return screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Targetable"))
        {
            Destroy(gameObject);
        }
    }
}
