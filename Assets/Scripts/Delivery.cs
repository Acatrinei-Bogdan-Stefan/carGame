using UnityEngine;


public class Delivery : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }

    bool hasPackage;
    [SerializeField] float destroyDelay = 0.5f;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
            
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered Package!");
            hasPackage = false;
            spriteRenderer.color = hasPackageColor;
        }

    }
    
    


}

