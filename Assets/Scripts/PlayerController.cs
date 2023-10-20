using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    [Header("Gameplay")]
    public float jumpForce;
    public bool isDead = false;
    [Header("Components")]
    private Animator playerAnimator;
    private Rigidbody playerRigidbody;
    [Header("Particles")]
    public ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        smoke.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDead)
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
        smoke.Play();
    }
}
