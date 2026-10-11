using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(SpriteRenderer))]

[RequireComponent(typeof(ParticleSystem))]
public class PlayerScript : MonoBehaviour
{
    public Camera mainCamera;
    SpriteRenderer sr;
    public Sprite Sitting;
    public Sprite Jumping;
    public float speed = 10f;
    float _speed;
    Vector3 velocity;
    public float fallSpeed = 30f;
    WoodScript currentPlatform = null;
    public Transform respawn;
    public GameObject startPlatform;
    bool showPath = false;
    public GameObject path;
    public float showPathTimeout = 2f;

    public UIScript uIScript;
    public CameraScript cameraScript;
    public float reSpawnTime = 1f;
    bool respawning = false;
    ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        _speed = speed;
        sr = GetComponent<SpriteRenderer>();
        transform.SetParent(startPlatform.transform);
        currentPlatform = startPlatform.GetComponent<WoodScript>();
        path.SetActive(false);
    }
    IEnumerator StartMove()
    {
        while (currentPlatform == null)
        {
            transform.position += Time.deltaTime * _speed * velocity;
            yield return null;
        }
        sr.sprite = Sitting;
        yield break;
    }
    public void OnString()
    {
        if (currentPlatform != null)
        {
            currentPlatform = null;
            transform.SetParent(null);
            sr.sprite = Jumping;
            velocity = transform.up;
            _speed = speed;
            StartCoroutine(StartMove());
        }
    }
    void OnRotate(InputValue input)
    {
        if (currentPlatform != null)
        {
            float val = input.Get<float>();
            if (val > 0)
            {
                currentPlatform.setRotate(-1);
            }
            else if (val < 0)
            {
                currentPlatform.setRotate(1);
            }
            else
            {
                currentPlatform.setRotate(0);
            }
        }
    }
    public void OnRotateButton(int val)
    {
        if (currentPlatform != null)
        {
            currentPlatform.setRotate(val);
        }
    }

    void OnShowPath(InputValue input)
    {
        float val = input.Get<float>();
        if (val == 0)
        {
            showPath = false;
        }
        else
        {
            StartCoroutine(ShowPathCoroutine());
        }
    }
    IEnumerator ShowPathCoroutine()
    {
        float time = 0f;
        showPath = true;
        path.SetActive(true);
        while (showPath && time < showPathTimeout)
        {
            time += Time.deltaTime;
            yield return null;
        }
        path.SetActive(false);
        yield return null;
    }
    public void newPlatform(WoodScript platform, Vector3 newUp)
    {
        transform.SetParent(platform.transform);
        currentPlatform = platform;
        transform.rotation = Quaternion.LookRotation(-Vector3.forward, newUp);
    }
    public void fall()
    {
        _speed = fallSpeed;
        transform.rotation = Quaternion.LookRotation(-Vector3.forward, Vector3.down);
        velocity = Vector3.down;
    }
    public void Respawn()
    {
        if(respawning) return;
        respawning = true;
        cameraScript.ShakeCamera();
        ps.Play();
        sr.enabled = false;
        _speed = 0;
        Invoke(nameof(ReplaceSpider), reSpawnTime);
    }
    void ReplaceSpider()
    {
        sr.enabled = true;
        if (respawn != null)
        {
            transform.position = respawn.position;
            transform.SetParent(startPlatform.transform);
            currentPlatform = startPlatform.GetComponent<WoodScript>();
            minusHealth();
        }
        respawning = false;
    }
    public void addStar()
    {
        uIScript.addStar();
    }
    public void minusHealth()
    {
            uIScript.minusHealth();
    }
}
