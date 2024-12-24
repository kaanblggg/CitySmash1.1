using UnityEngine;
using UnityEngine.AI;

public class PoliceAI : MonoBehaviour
{
    public float chaseDistance = 15f;
    public float stopDistance = 3f;
    public float resumeChaseDistance = 5f;
    public float chaseSpeed = 15f;
    public float stopSpeed = 0f;
    public float collisionPauseDuration = 1f; // Çarpışma sonrası bekleme süresi
    public float collisionIgnoreDuration = 3f; // Tekrar çarpışmayı engellemek için süre

    private Transform player;
    private NavMeshAgent agent;
    private bool isChasing = true;
    private bool isStoppedAfterCollision = false;
    private bool canCollide = true; // Çarpışma kontrolü için bayrak
    private Rigidbody rb;

    private void OnEnable() // OnEnable ile her sahne yüklendiğinde ayarları güncelle
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // NavMeshAgent ile daha iyi uyum için Rigidbody’yi kinematic yap
        ApplySettings();
    }

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player1");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player1 tag'li nesne bulunamadı!");
        }
    }

    private void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Çarpışma sonrası tekrar takip başlatma koşulu
        if (isStoppedAfterCollision && distanceToPlayer > resumeChaseDistance)
        {
            isStoppedAfterCollision = false;
            agent.isStopped = false;
            agent.speed = chaseSpeed;
        }

        // Takip ve durma işlemleri
        if (!isStoppedAfterCollision && isChasing)
        {
            agent.SetDestination(player.position);

            if (distanceToPlayer <= stopDistance)
            {
                agent.isStopped = true;
                agent.speed = stopSpeed;
                isStoppedAfterCollision = true;
            }
            else
            {
                agent.isStopped = false;
                agent.speed = chaseSpeed;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1") && canCollide)
        {
            // Çarpışma sonrası davranışlar
            agent.isStopped = true;
            agent.speed = 0;
            isStoppedAfterCollision = true;
            canCollide = false; // Çarpışmayı geçici olarak devre dışı bırak

            Invoke("ResumeChase", collisionPauseDuration); // Belirtilen süre sonra tekrar takip başlasın
            Invoke("EnableCollision", collisionIgnoreDuration); // Çarpışmayı belirli süre sonra tekrar etkinleştir
        }
    }

    private void ResumeChase()
    {
        agent.isStopped = false;
        agent.speed = chaseSpeed;
        isStoppedAfterCollision = false;
    }

    private void EnableCollision()
    {
        canCollide = true; // Çarpışmayı tekrar etkinleştir
    }

    private void ApplySettings() // Yeni ayarları burada belirle
    {
        agent.speed = chaseSpeed;
        agent.angularSpeed = 300f;
        agent.acceleration = 15f; // Daha yumuşak dönüşler için azaltıldı
        agent.stoppingDistance = stopDistance;
        agent.autoBraking = false;
    }
}
