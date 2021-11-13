using UnityEngine;

public class Boo : MonoBehaviour
{
    [HideInInspector]
    public Vector3 firePosition;
    public bool colidiuAlvo;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = firePosition;
    }

    void OnCollisionEnter(Collision other)
    {
        rb.useGravity = true;
        if (other.gameObject.CompareTag("Alvo"))
        {
            GameController.AdicionarPontos(10);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
