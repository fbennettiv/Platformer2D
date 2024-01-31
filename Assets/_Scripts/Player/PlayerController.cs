using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool isFacingRight = true;

    [HideInInspector]
    public bool isGrounded = false;

    public float jumpForce = 250f;
    public float maxSpeed = 7.0f;

    public Transform groundCheck;
    public LayerMask groundLayers;

    public float groundCheckRadius = 0.2f;
    public float timeToWait = 1f;

    public PhysicsMaterial2D jumpMaterial;

    private Animator anim;

    public AudioClip[] footstepSounds;
    public AudioClip jumpSound;
    public AudioClip damageSound;

    private AudioSource audioSource; //private is used to make sure something is not showing in the script menu

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Things like "transform, animator, etc, are components. So anything with this component is counted as a source
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                GetComponent<Rigidbody2D>().velocity =
                    new Vector2(
                        GetComponent<Rigidbody2D>().
                        velocity.x, 0);

                GetComponent<Rigidbody2D>().AddForce(
                    new Vector2(0, jumpForce));

                anim.SetTrigger("Jump");

                PlayJumpAudio();
            }
        }

        //float move = Input.GetAxis("Horizontal");
        
        if (Input.GetButtonDown("Horizontal"))
        {
            if (isGrounded)
            {
                //Invoke("PlayFootStepAudio", timeToWait);
                PlayFootStepAudio();
            }
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayers);

        PhysicsMaterial2D material = gameObject.GetComponent<CircleCollider2D>().sharedMaterial;

        if (isGrounded && material == jumpMaterial)
        {
            CircleCollider2D collision = gameObject.GetComponent<CircleCollider2D>();
            collision.sharedMaterial = null;
            collision.enabled = false;
            collision.enabled = true;
        }
        else if (!isGrounded && gameObject.GetComponent<CircleCollider2D>().sharedMaterial == null)
        {
            CircleCollider2D collision = gameObject.GetComponent<CircleCollider2D>();
            collision.sharedMaterial = jumpMaterial;
            collision.enabled = false;
            collision.enabled = true;
        }

        try
        {
            float move = Input.GetAxis("Horizontal");

            GetComponent<Rigidbody2D>().velocity =
                new Vector2(
                    move * maxSpeed,
                    GetComponent<Rigidbody2D>().velocity.y);

            anim.SetFloat("Speed", move);

            if (move < 0)
            {
                anim.SetFloat("Speed", move * -1);
            }

            if ((move > 0.0f && isFacingRight == false) ||
            (move < 0.0f && isFacingRight == true))
            {
                Flip();
            }
        }
        catch (UnityException error)
        {
            Debug.Log(error.ToString());
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    void PlayFootStepAudio()
    {
        audioSource.clip = footstepSounds[(Random.Range(0, footstepSounds.Length))];
        //audioSource.PlayDelayed(timeToWait);
        audioSource.Play();
    }

    void PlayJumpAudio()
    {
        AudioSource.PlayClipAtPoint(jumpSound, transform.position);
    }

    public void PlayDamageAudio()
    {
        audioSource.clip = damageSound;
        audioSource.Play();
    }

}
