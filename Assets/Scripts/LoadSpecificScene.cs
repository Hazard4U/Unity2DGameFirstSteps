using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.CompareTag("Player")){
            StartCoroutine("FadeUI");
        }
    }

    private IEnumerator FadeUI(){
        animator.SetTrigger("FadeUI");
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
