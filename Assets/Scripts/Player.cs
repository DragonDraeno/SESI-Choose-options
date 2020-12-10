using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerSpeed;
    private string playerName;

    [SerializeField] private AudioSource audioSource;
    [SerializeField]private Animator playerAnimator;

    public string PlayerName { get => playerName; set => playerName = value; }

    void Start()
    {
        playerSpeed = 4;
        PlayerName = "...";
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void Walk() {
        if (PlayerName != "...") {
            if (Input.GetAxis("Horizontal") > 0)
            {
                if (!audioSource.isPlaying) {
                    audioSource.Play();
                }
                transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
                transform.localScale = new Vector3(-0.6f, 0.5f, 0.5f);
                playerAnimator.SetBool("walk", true);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                playerAnimator.SetBool("walk", true);
                transform.localScale = new Vector3(0.6f, 0.5f, 0.5f);
                transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else {
                playerAnimator.SetBool("walk", false);
                audioSource.Pause();
            }
        }
    }
}
