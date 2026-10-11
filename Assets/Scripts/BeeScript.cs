using UnityEngine;

public class BeeScript : MonoBehaviour
{
    public Vector3 p1;
    public Vector3 p2;
    Vector3 diff;
    public AnimationCurve positionCurve;
    float timer;
    public float totalTime;
    public static bool autoSet = false;
    void Start()
    {
        timer = 0f;
        if (autoSet)
        {
            diff = p2-p1;
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = p1 + diff * positionCurve.Evaluate(timer/totalTime);
        if(timer > totalTime)
        {
            timer = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerScript>(out PlayerScript ps))
        {
            ps.Respawn();
        }
    }
    public void SetPos(float[] data, float time)
    {
        p1 = new Vector3(data[0],data[1],0);
        p2 = new Vector3(data[2],data[3],0);
        diff = p2-p1;
        totalTime = time;
    }
}
