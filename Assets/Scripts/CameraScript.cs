using System;
using System.Collections;
using UnityEngine;


public class CameraScript : MonoBehaviour
{
    public Camera mainCamera;
    public Transform background;
    public Transform player;
    public float yOffset = 0.4f;
    public Vector3 startPos;
    public float topEnd = 25;
    public AnimationCurve shakeCurve;
    public float shakeTime = 1f;
    bool isShaking = false;
    void Start()
    {
        transform.position = startPos;
        float size = 0;
        size = Math.Max(size, Math.Abs(background.localScale.y / 2));
        size = Math.Max(size, Math.Abs(background.localScale.x / 2) / Camera.main.aspect);
        mainCamera.orthographicSize = size;
        yOffset *= background.localScale.y;
    }
    void LateUpdate()
    {
        if (!isShaking && player.position.y > -7 && player.position.y < topEnd)
        {
            transform.position = new Vector3(0, player.position.y + yOffset, -10);
        }
    }
    public void ShakeCamera()
    {
        StartCoroutine(ShakeCoroutine());
    }
    IEnumerator ShakeCoroutine()
    {
        float timer = 0f;
        Vector3 tempPos = transform.position;
        isShaking = true;
        while (timer < shakeTime)
        {
            timer += Time.deltaTime;
            transform.position = tempPos + UnityEngine.Random.insideUnitSphere*shakeCurve.Evaluate(timer/shakeTime);
            yield return null;
        }
        transform.position = tempPos;
        isShaking = false;
        yield break;
    }
}
