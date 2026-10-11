using UnityEngine;

public class SlipperyWoodScript : WoodScript
{
    public GameObject rotatableArea;
    public float angle = 90f;
    public float startAngle = 90f;
    public static bool autoSetAngle = false;
    public virtual void Start()
    {
        if (autoSetAngle)
        {
            SetAngle(angle, startAngle);
        }
    }
    virtual public void SetAngle(float coverAngle, float startAngle)
    {
        angle = coverAngle;
        if (coverAngle >= 90f && coverAngle <= 180f)
        {
            rotatableArea.transform.RotateAround(transform.position, transform.forward, coverAngle-90f);
            transform.RotateAround(transform.position, transform.forward, startAngle);
        }
        else
        {
            Destroy(rotatableArea);
        }
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerScript>(out var ps))
        {
            Vector3 normal = collision.transform.position - transform.position;
            Debug.Log("Normal is "+ normal);
            float currentAngle = Vector3.SignedAngle(transform.right,normal, transform.forward);
            Debug.Log("Angle Of contact"+currentAngle+" Angle" + angle);
            Debug.Log("Position" +transform.position);
            if (currentAngle > angle || currentAngle < 0f)
            {
                ps.newPlatform(this, normal);
            }
            else
            {
                ps.fall();
            }
        }
        //base.OnTriggerEnter2D(collision);
    }
}
