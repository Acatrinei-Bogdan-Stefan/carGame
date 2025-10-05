using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 25f;


    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
         Debug.Log("Slowing down!");
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedBoost")
        {
            Debug.Log("Speeding Up!");
            moveSpeed = boostSpeed;
        }

    }


    
}
