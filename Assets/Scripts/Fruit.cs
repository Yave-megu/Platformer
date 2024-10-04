using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float TimeAdded = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           GameManager.Instance.AddTime(TimeAdded);
           GetComponent<Animator>().SetTrigger("Eaten");
           GetComponent<Collider2D>().enabled = false;
           
        }
    }
    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
