using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPositionGameObject : MonoBehaviour
{
    private Vector3 targetPosition;
    private float speed;

    private void Update()
    {
        Move(Time.deltaTime);
        TestReachedTargetPosition();
    }

    private void Move(float deltaTime)
    {
        Vector3 direction =  (targetPosition - transform.position).normalized;
        transform.position += direction * deltaTime * speed;
    }

    private void TestReachedTargetPosition()
    {
        float reachedTargetDistance = .5f;
        if (Vector3.Distance(transform.position, targetPosition) < reachedTargetDistance)
        {
            targetPosition = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3( 
            UnityEngine.Random.Range (0f, 15f),
            0,
            UnityEngine.Random.Range(0f, 15f)
            );
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
