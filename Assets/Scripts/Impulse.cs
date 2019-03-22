using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour{

public CharacterController2D Player;
public float xForce;
public float yForce;
public int waittime = 5;

private void Awake() 
{
	CharacterController2D Player = gameObject.GetComponent<CharacterController2D>();
}

private void OnTriggerEnter2D(Collider2D other) 
{
    Player.Impulse(xForce, yForce);
	MudarEstadoComponente(this.gameObject, false);
	StartCoroutine(Respawn());
}

public void MudarEstadoComponente(GameObject Comp, bool estado)
{
	Comp.GetComponent<Renderer>().enabled = estado;
	Comp.GetComponent<BoxCollider2D>().enabled = estado;
}

IEnumerator Respawn()
{
    yield return new WaitForSeconds(waittime);
    MudarEstadoComponente(this.gameObject, true);
}

}