using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    [Header("Movement")]
    public float jumpForce;
    private Animator playerAnimator;
    private Rigidbody playerRigidbody;
    public bool isDead = false;
    public ParticleSystem sparkles;
    public ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        sparkles.Play();
        smoke.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if((transform.position.y >= 5 || transform.position.y <= -5) && !isDead)
        {
            Die();
        } else if(transform.position.y <= -5 && isDead){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        playerAnimator.SetTrigger("Death");
        isDead = true;
        Debug.Log("You Died.");
        sparkles.Stop();
        smoke.Play();
    }
}
