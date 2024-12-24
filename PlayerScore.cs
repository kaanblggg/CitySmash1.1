using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
   public static PlayerScore Instance;
   public int score = 0;
   public Text scoreText;
   public PoliceSpawner policeSpawner; // PoliceSpawner referansı
   public TurboButtonController turboButtonController;

   private void Awake()
   {
       if (Instance == null)
       {
           Instance = this;
       }
       else
       {
           Destroy(gameObject);
       }
   }

   public void AddScore(int value)
   {
       score += value;
       UpdateScoreText();

       if (score % 25 == 0)
       {
        turboButtonController.EnableTurboButton();
       }

       // Eğer skor 20 veya üstüne ulaştıysa ikinci polis arabasını spawn et
       if (score >= 20)
       {
           policeSpawner.SpawnSecondPolice();
       }

       if(score >=50)
       {
        policeSpawner.SpawnThirdPolice();
       }

       if(score >= 100)
       {
        policeSpawner.SpawnFourthPolice();
       }

       if(score >= 150)
       {
        policeSpawner.SpawnFivePolice();
       }

    
   }

   private void UpdateScoreText()
   {
       scoreText.text = "SKOR : " + score;
   }
}
