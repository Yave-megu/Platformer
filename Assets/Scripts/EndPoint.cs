using UnityEngine;

public class EndPoint : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("You Win!");
        }
    }
}
