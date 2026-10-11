using UnityEngine;

public class StarScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerScript ps))
        {
            ps.addStar();  
            Destroy(gameObject); 
        }
    }
}
