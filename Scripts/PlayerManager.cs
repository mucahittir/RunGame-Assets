using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update 
    Rigidbody2D rigidbody;
    public float gucMiktari;
    public bool isGrounded;
    int sayac = 0;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OnGroundCheck();
        if (Input.GetButton("Jump") && isGrounded)
        {
            sayac = 25;
            rigidbody.AddForce(transform.up * gucMiktari);
        }
        else if (Input.GetButton("Jump") && sayac > 0)
        {
            rigidbody.AddForce(transform.up * sayac);
            sayac--;
        }
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(2);
        }
    }
}
