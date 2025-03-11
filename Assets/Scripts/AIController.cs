using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public float jumpForce = 5f;
    public float torqueForce = 10f;
    public GameObject target;
    public float jumpInterval = 2f;
    private Rigidbody rb;
    private float timer = 0f;
    private bool isActive = false; 


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("ActivateAI", 2f);
    }

    void Update()
    {
        if (!isActive) return;
        timer += Time.deltaTime;

        if (timer >= jumpInterval)
        {
            JumpToTarget();
            timer = 0f;
        }
    }

    void ActivateAI()
    {
        isActive = true;
    }

    void JumpToTarget()
    {
        Vector3 directionToTarget = (target.transform.position - transform.position).normalized;
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        rb.AddForce(directionToTarget * jumpForce, ForceMode.Impulse);

        Vector3 randomTorque = new Vector3(
            Random.Range(-torqueForce, torqueForce),
            Random.Range(-torqueForce, torqueForce),
            Random.Range(-torqueForce, torqueForce)
        );
        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
            {
               gameManager.IncrementBotScore();
            }
    }
}