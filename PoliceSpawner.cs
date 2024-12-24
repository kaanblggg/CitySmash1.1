using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    public GameObject policePrefab;    // Polis arabası prefab'i
    public Transform spawnPoint;       // İkinci polis arabasının spawn olacağı konum
    private bool secondPoliceSpawned = false;
    private bool thirdPoliceSpawned = false;
    private bool fourthPoliceSpawned = false;
    private bool fivethPolicSpawned = false;

    // İkinci polis arabasını spawn etme
    public void SpawnSecondPolice()
    {
        if (!secondPoliceSpawned)
        {
            Instantiate(policePrefab, spawnPoint.position, spawnPoint.rotation);
            secondPoliceSpawned = true;
          //  Debug.Log("İkinci polis arabası spawn edildi!");
        }

       
    }
    public void SpawnThirdPolice()
    {
         if (!thirdPoliceSpawned)
        {
            Instantiate(policePrefab, spawnPoint.position, spawnPoint.rotation);
            thirdPoliceSpawned = true;
          //  Debug.Log("Üçüncü polis arabası spawn edildi!");
        }
    }

    public void SpawnFourthPolice()
    {
        if(!fourthPoliceSpawned)
        {
            Instantiate(policePrefab, spawnPoint.position, spawnPoint.rotation);
            fourthPoliceSpawned = true;
           // Debug.Log("Dördüncü polis arabası spawn edildi!");
        }
    }

    public void SpawnFivePolice()
    {
        if(!fivethPolicSpawned)
        {
            Instantiate(policePrefab, spawnPoint.position, spawnPoint.rotation);
            fivethPolicSpawned = true;
        }
    }
}
