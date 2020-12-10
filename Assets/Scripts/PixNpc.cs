using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PixNpc : MonoBehaviour
{
    private bool endAnimation;
    private bool pixTalk;

    [SerializeField] TextMeshPro textPix;

    [SerializeField] Player player;

    public bool EndAnimation { get => endAnimation; set => endAnimation = value; }
    public bool PixTalk { get => pixTalk; set => pixTalk = value; }

    void Start()
    {
        EndAnimation = false;
        PixTalk = false;
        textPix.text = " ";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && EndAnimation == true)
        {
            PixTalk = true;
            PixScondTalk();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && EndAnimation == true)
        {
            PixTalk = false;
            textPix.text = " ";
        }
    }


    public void EndedAnimation()
    {
        EndAnimation = true;
    }

    public void PixScondTalk()
    {
        textPix.text = player.PlayerName + " você viu os cursos do SESI? só seguir para direita. não tem erro!.";
    }
}
