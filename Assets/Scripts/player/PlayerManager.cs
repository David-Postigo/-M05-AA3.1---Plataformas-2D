using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int lifes = 3;
    public int coins = 0;

    [Header("Damage Settings")]
    public float invulnerabilityTime = 1.5f;
    public float blinkInterval = 0.1f;

    private bool isInvulnerable = false;
    private float invulTimer = 0f;
    private float blinkTimer = 0f;

    private SpriteRenderer sprite;
    private Color ogcolor;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ogcolor = sprite.color;
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
        if (isInvulnerable) return;

        lifes--;

        if (lifes <= 0)
        {
            die();
            return;
        }

        isInvulnerable = true;
        invulTimer = invulnerabilityTime;
        blinkTimer = 0f;
    }

    void die()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void grabcoin()
    {
        coins++;
    }
}