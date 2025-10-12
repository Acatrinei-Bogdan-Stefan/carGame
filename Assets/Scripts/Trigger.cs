using UnityEngine;

public class Trigger : MonoBehaviour
{

    bool hasPackage;
    [SerializeField] float destroyDelay = 0.3f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, destroyDelay);
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            GetComponent<ParticleSystem>().Stop();
            hasPackage = false;
            Destroy(collision.gameObject);
        }

    }
}
