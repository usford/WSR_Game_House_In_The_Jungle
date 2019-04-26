using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Tooltip("Скорость персонажа")]
    [SerializeField]
    private float speed = 2.0f;

    [Tooltip("Характеристика")]
    [SerializeField]
    private Characteristic characteristicData;

    Rigidbody2D rb;
    SpriteRenderer sprite;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetButton("Horizontal")) Run();
        if (Input.GetButton("Vertical")) UpDown();
    }

    /// <summary>
    /// Передвижение влево-вправо
    /// </summary>    
    void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * speed);

        sprite.flipX = direction.x < 0.0f;
    }

    /// <summary>
    /// Передвижение вверх-вниз
    /// </summary>
    void UpDown()
    {
        Vector3 direction = transform.up * Input.GetAxis("Vertical");


        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * speed);
    }
}
