using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public CharacterController2D playerController;


    void Ativar(){
        playerMovement.enabled=true;
        playerController.enabled=true;
    }
    void Desativar(){
        playerMovement.enabled=false;
        playerController.enabled=false;
    }
}
