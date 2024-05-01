using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip grassFootstepSound;
    public AudioClip asphaltFootstepSound;

    private AudioSource audioSource;
    private Rigidbody2D rb;
    private AudioClip currentFootstepSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Send"))
        {
            if (currentFootstepSound != grassFootstepSound || !audioSource.isPlaying || rb.velocity.magnitude <= 0.1f)
            {
                currentFootstepSound = grassFootstepSound;
                PlayAndStopFootstepSound(currentFootstepSound);
            }
        }
        else if (collision.CompareTag("Wood"))
        {
            if (currentFootstepSound != asphaltFootstepSound || !audioSource.isPlaying || rb.velocity.magnitude <= 0.1f)
            {
                currentFootstepSound = asphaltFootstepSound;
                PlayAndStopFootstepSound(currentFootstepSound);
            }
        }
    }

    private void PlayAndStopFootstepSound(AudioClip footstepSound)
    {
        if (footstepSound != null && rb.velocity.magnitude > 0.1f)
        {
            audioSource.clip = footstepSound;
            
            audioSource.Play();
        }
        else if (rb.velocity.magnitude <= 0.1f)
        {
            audioSource.Stop();
            
        }
    }
}