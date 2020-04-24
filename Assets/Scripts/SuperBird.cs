using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBird : MonoBehaviour
{

    Rigidbody rb;
    public float jumpPower = 3f;
    public float forwardSpeed = 1f;
    public GamePlayManager gm;
    public float maxSpeed = 3f;
    public AudioSource audioFly;

    // public float timeInterval = 0.5f;
    // float accumTime = 0;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GamePlayManager>();
        InvokeRepeating("MyUpdate", 0, 0.1f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            audioFly.Play();
        }

        Vector3 boundScreen = Camera.main.WorldToScreenPoint(transform.position);
        float distY = Vector3.Distance(new Vector3(0f, Screen.height / 2, 0f), new Vector3(0f, boundScreen.y, 0f));

        print(distY);

        if (distY > Screen.height / 1.5) {
            print("bound screen");
            gm.GameOver();
            rb.isKinematic = true;
        }
    }

    void FixedUpdate() {
        // accumTime += Time.fixedDeltaTime;
        // if (accumTime >= timeInterval) {
        //    rb.AddForce(Vector3.right * forwardSpeed);
        //    accumTime = 0;
        // }
        rb.AddForce(Vector3.right * forwardSpeed);
        if (rb.velocity.magnitude > maxSpeed) {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    void MyUpdate() {
        // rb.velocity = Vector3.right * forwardSpeed;
        // rb.AddForce(Vector3.right * forwardSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        print("Collision");
        // print("Game Over");
        gm.GameOver();
        rb.isKinematic = true;
    }
}
