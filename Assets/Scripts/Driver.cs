using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float regularSpeed = 10f;
    [SerializeField] float currentSpeed = 10f;
    [SerializeField] float boostSpeed = 20f;

    [SerializeField] TMP_Text boostText;
    [SerializeField] TMP_Text objectiveText;

    void Start()
    {
        boostText.gameObject.SetActive(false);
    }

    void Update()
    {

        float steerAmount = 0f;
        float moveAmount = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            moveAmount = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            moveAmount = -1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steerAmount = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steerAmount = -1f;
        }

        transform.Rotate(0, 0, steerAmount * steerSpeed * Time.deltaTime);
        transform.Translate(0, moveAmount * currentSpeed * Time.deltaTime, 0);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WorldCollision"))
        {
            currentSpeed = regularSpeed;
            boostText.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedBoost"))
        {
            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }

    }


    
}
