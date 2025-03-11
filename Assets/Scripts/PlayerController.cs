using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public float jumpForce = 5f;
    public float torqueForce = 10f;
    public GameObject target;
    private Rigidbody rb;
    private bool isActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("ActivatePlayer", 2f);
    }

    void Update()
    {
        if (!isActive) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpToTarget();
        }
    }

    void ActivatePlayer()
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
            gameManager.IncrementPlayerScore();
        }
    }
}