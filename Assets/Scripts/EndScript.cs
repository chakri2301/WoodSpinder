using UnityEngine;

public class EndScript : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerScript ps))
        {   
                ps.Respawn();   
        }
    }
}
