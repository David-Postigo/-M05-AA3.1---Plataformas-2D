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
        ogcolor = GetComponent<Color>();
    }
    void Update()
    {

        if (isInvulnerable)
        {
            invulTimer -= Time.deltaTime;
            blinkTimer -= Time.deltaTime;

            if (blinkTimer <= 0f)
            {
                if (sprite.color == ogcolor)
                    sprite.color = Color.red;
                else
                    sprite.color = ogcolor;

                blinkTimer = blinkInterval;
            }


            if (invulTimer <= 0f)
            {
                isInvulnerable = false;
                sprite.color = ogcolor;
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

        // Activar invulnerabilidad
        isInvulnerable = true;
        invulTimer = invulnerabilityTime;
        blinkTimer = 0f; // empieza parpadeo inmediato
    }
    void die()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void grabcoin()
    {
        coins++;
    }
}
