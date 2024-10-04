using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Debug.Log("You Lose!");
            GameManager.Instance.Die();
        }
    }
}
