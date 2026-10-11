using UnityEngine;

public class WoodScript : MonoBehaviour
{
    protected float currentSpeed = 0f;
    public float rotateSpeed = 20f;
    public virtual void setRotate(float mul)
    {
        //print(rotateSpeed);
        currentSpeed = rotateSpeed * mul;
    }
    void Update()
    {
        transform.Rotate(transform.forward, currentSpeed * Time.deltaTime);
    }
    virtual public void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Triggered");
        if (collision.gameObject.TryGetComponent<PlayerScript>(out var ps))
        {
            ps.newPlatform(this, collision.transform.position - transform.position);
        }
    }
}
