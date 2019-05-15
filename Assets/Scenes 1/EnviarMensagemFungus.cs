using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class EnviarMensagemFungus : MonoBehaviour
{
    public string mensagem;
    public PlayerMovement playerMovement;
    public CharacterController2D playerController;
    private int contador = 0;
    

    private void Start()
    {
        //playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "player" && contador == 0)
        {
            contador = 1;
            playerMovement.enabled=false;
            playerController.enabled=false;
            Fungus.Flowchart.BroadcastFungusMessage(mensagem);
            mensagem = "a";
        }
    }
}
