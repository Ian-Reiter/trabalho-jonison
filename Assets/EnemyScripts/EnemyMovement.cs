using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] WayPoints;
    public int currentPoint;

    public float enemySpeed;
    public float lastPositionX;
    void Start()
    {
        currentPoint = 0;
        transform.position = WayPoints[currentPoint].position;
    }

    void Update()
    {
        Movement();
        HorizontalFlip();
    }

    public void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, WayPoints[currentPoint].position, enemySpeed * Time.deltaTime);

        if(transform.position == WayPoints[currentPoint].position)
        {
            currentPoint += 1;

            lastPositionX = transform.localPosition.x;

            if(currentPoint >= WayPoints.Length)
            {
                currentPoint = 0;
            }
        }
    }

    public void HorizontalFlip()
    {
        if(transform.localPosition.x < lastPositionX)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(transform.localPosition.x > lastPositionX)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
