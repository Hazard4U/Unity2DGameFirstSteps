using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public GameObject[] gameObjects;
    void Awake(){
        foreach (var gameObject in gameObjects)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
