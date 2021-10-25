using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject gameObjectToDestroy;
    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.CompareTag("Player")){
            Destroy(gameObjectToDestroy);
        }
    }
}
