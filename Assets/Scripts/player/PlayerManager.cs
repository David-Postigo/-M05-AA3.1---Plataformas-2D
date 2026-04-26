using NUnit.Framework.Internal;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class PlayerManager : MonoBehaviour
{
    
    [Header("Basic Settings")]
    public float lifes = 3;
    public int coins = 0;
    public float pushforce = 1000;
    [Header("Damage Settings")]
    public float invulnerabilityTime = 1.5f;
    public float blinkInterval = 0.1f;
    public bool shieldactive;

    private bool isInvulnerable = false;
    private float invulTimer = 0f;
    private float blinkTimer = 0f;

    private SpriteRenderer sprite;
    private Color ogcolor;
    private Rigidbody2D rb;
    [Header("Coin audio")]
    public AudioClip sound;
    public AudioClip sound2;
    private AudioSource source;

    public TextMeshProUGUI text;
    public TextMeshProUGUI texthp;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ogcolor = sprite.color;
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        texthp.text = lifes.ToString();
    }

    void Update()
    {
        if (isInvulnerable)
        {
            invulTimer -= Time.deltaTime;
            blinkTimer -= Time.deltaTime;

            if (blinkTimer <= 0f)
            {
                if (sprite.color == Color.red)
                    sprite.color = ogcolor;
                else
                    sprite.color = Color.red;

                blinkTimer = blinkInterval;
            }

            if (invulTimer <= 0f)
            {
                isInvulnerable = false;
                sprite.color = ogcolor; // restore correctly
            }
        }
    }

    public void Damage()
    {
        source.PlayOneShot(sound2);
        if (isInvulnerable) return;
        if (shieldactive)
        {
            lifes -= 0.5f;
        }
        else { 
            lifes--;
        }
        if (lifes <= 0)
        {
            die();
            return;
        }

        isInvulnerable = true;
        invulTimer = invulnerabilityTime;
        blinkTimer = 0f;
        texthp.text = lifes.ToString();
    }
    public void heal()
    {
        lifes++;
        texthp.text = lifes.ToString();
    }
    public void die()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void grabcoin()
    {
        coins++;
        source.PlayOneShot(sound);
        text.text = coins.ToString();
    }

    public void push()
    {
        float direction = sprite.flipX ? 1f : -1f;

        rb.AddForce(new Vector2(direction * pushforce, 2f), ForceMode2D.Impulse);
    }
    public void shield_damge()
    {
        if (isInvulnerable) return;

        lifes = lifes - 0.5f;

        if (lifes <= 0)
        {
            die();
            return;
        }

        isInvulnerable = true;
        invulTimer = invulnerabilityTime;
        blinkTimer = 0f;
        
    }
}