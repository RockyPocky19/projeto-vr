using UnityEngine;

public class RandomMover : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float waitTime = 1f;

    private Vector3 targetPos;
    private float timer;

    void Start()
    {
        PickNewTarget();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPos) < 0.05f)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                PickNewTarget();
                timer = 0f;
            }
        }
    }

    void PickNewTarget()
    {
        float x = Random.Range(PointsPosClass.minX, PointsPosClass.maxX);
        float y = Random.Range(PointsPosClass.minY, PointsPosClass.maxY);
        float z = Random.Range(PointsPosClass.minZ, PointsPosClass.maxZ);

        targetPos = new Vector3(x, y, z);
    }
}
