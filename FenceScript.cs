using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour
{
    public int health = 5; // Çitin sağlığı

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet") // Mermi çarpınca
        {
            Destroy(collision.gameObject); // Mermiyi yok et
            health--; // Sağlığı azalt

            if (health <= 0) // Sağlık 0 olunca çiti yok et
            {
                Destroy(gameObject); // Çiti yok et
            }
        }
    }
}
