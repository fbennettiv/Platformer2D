using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health = 6;

    //Copper = 1, Silver = 3, Gold = 6.
    public int coinsCollected = 0;

    public Transform open;
    public Transform close;

    private SpriteRenderer spriteRenderer;

    public bool isDead = false;
    public float deathTimeElasped;

    private GameObject HUDCamera;
    private GameObject HUDScore;
    private GameObject Door;
    public Door openDoor;

    public bool redDiamond = false, 
        blueDiamond = false, 
        greenDiamond = false, 
        yellowDiamond = false,
        allTrue = true;

    public void Start()
    {
        spriteRenderer = 
            this.gameObject.GetComponent<SpriteRenderer>();

        HUDCamera = GameObject.FindGameObjectWithTag("HUDCamera");
        HUDScore = GameObject.FindGameObjectWithTag("HUDScore");
        Door = GameObject.FindGameObjectWithTag("Door");

        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            coinsCollected = PlayerPrefs.GetInt("Coins");
        }

        PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
    }

    public void Update()
    {
        if (this.isDead)
        {
            this.deathTimeElasped += Time.deltaTime;

            if (this.deathTimeElasped >= 1.0f)
            {
                SceneManager.LoadScene(6);
            }
        }

        //Door.GetComponent<Collider2D>().enabled = false;

        /*
        if (Input.GetMouseButtonDown(0))
        {
            Door.GetComponent<Collider2D>().enabled = true;
        }*/
    }

    public void CollectCoin(int coinValue)
    {
        coinsCollected += coinValue;
        HUDScore.GetComponent<CoinCounter>().value = coinsCollected;
    }

    public void CollectDiamonds(int diamondNum)
    {
        switch (diamondNum)
        {
            case 1:// Blue
                {
                    blueDiamond = true;
                    break;
                }
            case 2: //Green
                {
                    greenDiamond = true;
                    break;
                }
            case 3: //Red
                {
                    redDiamond = true;
                    break;
                }
            case 4: //Yellow
                {
                    yellowDiamond = true;
                    allTrue = true;
                    break;
                }
        }

        HUDCamera.GetComponent<GUIGame>().UpdateDiamond(diamondNum);

        
        if (allTrue)
        {
            SceneManager.LoadScene(5);
        }
    }

    public void TakeDamage(int damage) // (int damage, bool playHitReaction)
    {

        PlayerController controller =
            this.gameObject.GetComponent<PlayerController>();
        controller.PlayDamageAudio();

        health -= damage;
        HUDCamera.GetComponent<GUIGame>().UpdateHealth(health);

        if (health == 0)
        {
            PlayerIsDead();
        }

        gameObject.GetComponent<Rigidbody2D>().
            velocity = new Vector2(0, 0);


        if (controller.isFacingRight)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 400));
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 400));
        }
    }

    void PlayerIsDead()
    {
        this.isDead = true;

        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;

        SceneManager.LoadScene(6);
    }
}
