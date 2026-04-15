using UnityEngine;

public class Bullet : MonoBehaviour
{  
    public float speed;
    public float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }
}
