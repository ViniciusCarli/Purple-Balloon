using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudardeCena : MonoBehaviour
{
    public string Cena;
    public void ChangeScene()
    {
        Application.LoadLevel(Cena);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "player"){
            StartCoroutine(PlzWaitSir());
        }
    }
    

    IEnumerator PlzWaitSir()
    {
        print("changing scene...");
        yield return new WaitForSeconds(0.5f);
        ChangeScene(); 
    }

}
