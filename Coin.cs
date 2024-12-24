using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource coinAudio;
    
    private void Start(){
        coinAudio = GetComponent<AudioSource>();
    }    
   private void OnTriggerEnter(Collider other){

        if(other.CompareTag("Player1")){

            coinAudio.Play();

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            Destroy(gameObject, coinAudio.clip.length);

            PlayerScore.Instance.AddScore(1);
            FindObjectOfType<WowEffectController>().AddCoin(); //Bu 15 coin toplama sesi beğenmezsen çıkart ve wowcoin scriptini iptal et
            
        }
    }
}
