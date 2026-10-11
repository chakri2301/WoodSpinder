public class StationaryWoodScript : WoodScript
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = rotateSpeed;
    }
    public override void setRotate(float mul)
    {
        //base.setRotate(mul);
    }
    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }
}
