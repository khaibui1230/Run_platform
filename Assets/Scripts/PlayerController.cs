using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtPaticle;
    public float JumpForce;
    public float gravityModifier;
    private bool isOnGRound = true;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>(); // luc nhay
        playerAnim= GetComponent<Animator>();
        Physics.gravity *= gravityModifier; // trong luc
        // prevent player double jump
        // check the character if they don't isOnGround then do not space
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // khoi tao cho doi tuong bay len khi nhan nut space, tu ham rigidbody
        if (Input.GetKeyDown(KeyCode.Space) && isOnGRound && !gameOver)
        {
            playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnGRound = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtPaticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGRound = true; //xac dinh xem nhan vat co o tren mat dat khong
            dirtPaticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtPaticle.Stop(true);
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

}
