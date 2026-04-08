using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveDistance = 0.2f;
    public float speed = 5f;
    private Vector3 startPos;
    private Animator animator;

    void Start()
    {
        startPos = transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(GameManager.isGamePaused || GameManager.isGameOver)
            return;

        float movement = Mathf.Sin(Time.time * speed) * moveDistance;
        transform.position = new Vector3(startPos.x + movement, transform.position.y, 0);

        animator.SetFloat("speed", MathF.Abs(movement));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver(collision.gameObject.GetComponent<PlayerJump>());
        }
    }
}

