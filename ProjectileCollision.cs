using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bina")  // Bina ile çarpışmayı kontrol et
        {
            Destroy(collision.gameObject);  // Binayı yok et
            Destroy(gameObject);  // Mermiyi de yok et
        }
    }
}
