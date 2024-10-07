using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 Velocity = new Vector2(10, 0);

    private void Update()
    {
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            Debug.Log("Bullet hit terrain");
            gameObject.SetActive(false);
        }
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Bullet hit enemy");
            gameObject.SetActive(false);
            collision.gameObject.GetComponent<EnemyController>().Hit(1);
        }
    }
}
