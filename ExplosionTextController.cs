using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionTextController : MonoBehaviour
{
    public float displayTime = 1.5f;
    private Text explasionText;
    void Start()
    {
        explasionText = GetComponent<Text>();
        explasionText.enabled = false;
    }

    public void ShowExplosionText(){
        StartCoroutine(ShowTextRoutine());
    }

    IEnumerator ShowTextRoutine(){
        explasionText.enabled = true;

        yield return new WaitForSeconds(displayTime);

        explasionText.enabled = false;
    }

    
    
}
