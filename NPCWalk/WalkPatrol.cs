using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPatrol : MonoBehaviour
{
    public float speed;
    public Transform leftPoint; // Левая точка, до которой объект должен дойти
    public Transform rightPoint; // Правая точка, до которой объект должен дойти

    private bool movingRight = true;

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= rightPoint.position.x)
            {
                // Если достигли правой точки, разворачиваемся и движемся влево
                Razvorot();
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= leftPoint.position.x)
            {
                // Если достигли левой точки, разворачиваемся и движемся вправо
                Razvorot();
            }
        }
    }

    void Razvorot()
    {
        // Меняем направление движения и разворачиваем объект на 180 градусов
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
