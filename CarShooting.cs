using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarShooting : MonoBehaviour
{
    public GameObject projectilePrefab;  // Mermi prefab'i
    public Transform firingPoint;  // Ateşleme noktası
    public float projectileSpeed = 20f;  // Mermi hızı
    public ParticleSystem fireEffect; // Ateş efekti için Particle System

    // Bu metod, butona basıldığında çağrılacak
    public void Shoot()
{
    GameObject projectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
    Rigidbody rb = projectile.GetComponent<Rigidbody>();
    rb.velocity = firingPoint.forward * projectileSpeed;

    if (fireEffect != null)
    {
        fireEffect.gameObject.SetActive(true);  // Efekti aktif et
        fireEffect.Play();
        StartCoroutine(DisableFireEffect());
        Destroy(projectile, 2f);

    }
}

private IEnumerator DisableFireEffect()
{
    yield return new WaitForSeconds(0.2f);  // Efektin kısa bir süre görünmesi için bekletme süresi
    fireEffect.gameObject.SetActive(false);  // Efekti devre dışı bırak
}
}
