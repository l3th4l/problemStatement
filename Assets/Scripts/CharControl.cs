using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    [SerializeField]
    KeyCode JumpKey;

    [SerializeField]
    GameObject ForceSliderObject;

    [SerializeField]
    ScoreCount ScoreCounter;
    [SerializeField]
    PlatformSpawn PlatSpawner;

    [SerializeField]
    float MaxJumpForce;
    [SerializeField]
    float MaxBuildupTime;

    [SerializeField]
    int ScorePerLand;

    Rigidbody2D RB;
    ForceDisplaySlider ForceSlider;

    public Vector2 jumpDir;
    public bool dead;

    float buildupTime;
    float mousePressTime;
    float mouseReleaseTime; 

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        ForceSlider = ForceSliderObject.GetComponent<ForceDisplaySlider>();
        ScoreCounter = GameObject.FindGameObjectWithTag("score_system").GetComponent<ScoreCount>();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(JumpKey))
        {
            mousePressTime = Time.time;
        }

        if(Input.GetKey(JumpKey))
        {
            ForceSliderObject.SetActive(true);
            ForceSlider.pressedTime = (Time.time - mousePressTime) / MaxBuildupTime;
        }
        else
        {
            ForceSlider.pressedTime = 0;
            ForceSliderObject.SetActive(false);
        }

        if (Input.GetKeyUp(JumpKey))
        {
            mouseReleaseTime = Time.time;

            buildupTime = (mouseReleaseTime - mousePressTime) / MaxBuildupTime; // Normalized
            buildupTime = Mathf.Clamp01(buildupTime);

            jump(buildupTime, jumpDir, MaxJumpForce);
        }
    }

    void jump(float _buildupTime, Vector2 _jumpDir, float _MaxJumpForce)
    {
        RB.AddForce(_jumpDir * _buildupTime * _MaxJumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.collider.tag);

        if (collision.collider.CompareTag("platform"))
        {
            ScoreCounter.addScore(ScorePerLand);

            if(ScoreCounter.Score > 0)
                PlatSpawner.spawnPlatform();
        }

        if (collision.collider.CompareTag("death_trigger"))
        {
            Time.timeScale = 0.0f;
            dead = true;
        }
    }
}