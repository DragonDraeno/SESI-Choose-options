using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private bool pixFirstTalk;

    [SerializeField] private PixNpc pixNpc;
    [SerializeField] private Player player;

    [SerializeField] TextMeshPro textPix;

    [SerializeField] GameObject playerNameIpt;
    [SerializeField] TextMeshProUGUI playerNameImputText;

    [SerializeField] GameObject playerNameBtn;

    private Coroutine InitializePix;
    private Coroutine countDownICoroutine;
    private Coroutine PixICoroutine;

    void Start()
    {
        pixFirstTalk = true;
            
        InitializePix = StartCoroutine(pixInitialize());
        countDownICoroutine = null;
        PixICoroutine = null;
    }

    private void Update()
    {
        if (!pixFirstTalk)
        {
            if (pixNpc.PixTalk == false)
            {
                textPix.text = " ";
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }


    IEnumerator pixInitialize()
    {
        while (!pixNpc.EndAnimation)
        {
            yield return null;
        }
        textPix.text = "Ola aventureiro, eu sou Penny o espirito desta ilha, qual o seu nome? " + player.PlayerName;
        playerNameIpt.SetActive(true);
        playerNameBtn.SetActive(true);
    }

    public void UpdatePlayerName() {
        playerNameIpt.SetActive(false);
        playerNameBtn.SetActive(false);
        StopCoroutine(InitializePix);
        player.PlayerName = playerNameImputText.text;
        textPix.text = "é bom conhecer você " + player.PlayerName + " você deve ter vindo ver os cursos do SESI não é mesmo? basta seguir até o fim da ilha. nao tem como se perder... eu espero.";

        countDownICoroutine = StartCoroutine(CauntDown());
        
    }

    IEnumerator CauntDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(8);
            pixFirstTalk = false;
        }
    }
}
