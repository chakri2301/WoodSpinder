public class SlipperyStationaryScript : SlipperyWoodScript
{
    public override void Start()
    {
        if (autoSetAngle)
        {
            setStartSpeed(rotateSpeed);
        }
        base.Start();
    }
    public override void setRotate(float mul)
    {
        //base.setRotate(mul);
    }
    public void setStartSpeed(float rotateSpeed)
    {
        currentSpeed = rotateSpeed;
    }
}

