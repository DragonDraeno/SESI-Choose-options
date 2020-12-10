using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private GameObject parchment;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            parchment.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            parchment.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
