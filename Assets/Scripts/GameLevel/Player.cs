using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public TrailRenderer tr;
    public CircleCollider2D collider;
    public string currentColor;
    public Color colorCyan;
    public Color colorYellow;
    public Color colorPink;
    public Color colorPurple;
    private Scene activeScene;
    public AudioClip gameOverSound;

    private void Start()
    {
        // Get active scene name.
        activeScene = SceneManager.GetActiveScene();

        // Player start random color.
        SetRandomColor();
    }

    private void Update()
    {
        // Player jump.
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Player hit ColorChanger.
        if (other.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(other.gameObject);
        }

        // Player hit FinishObject.
        else if (other.tag == "FinishObject")
        {
            int NextLevel = int.Parse(activeScene.name);
            NextLevel++;
            SceneManager.LoadScene(NextLevel);
        }

        // Player hit FallLimit object.
        else if (other.tag == "FallLimit")
        {
            // Play game over sound.
            GameObject.FindGameObjectWithTag("EffectSoundManager").GetComponent<AudioSource>().PlayOneShot(gameOverSound);

            // Game Over function.
            StartCoroutine(GameOver());
        }

        // Player hit wrong color.
        else if (other.tag != currentColor)
        {
            // Play game over sound.
            GameObject.FindGameObjectWithTag("EffectSoundManager").GetComponent<AudioSource>().PlayOneShot(gameOverSound);

            // Game Over function.
            StartCoroutine(GameOver());
        }
    }

    public void SetRandomColor()
    {
        int index = Random.Range(0, 3);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
            case 3:
                currentColor = "Purple";
                sr.color = colorPurple;
                break;
        }
    }

    IEnumerator GameOver()
    {
        sr = this.GetComponent<SpriteRenderer>();
        tr = this.GetComponent<TrailRenderer>();
        collider = this.GetComponent<CircleCollider2D>();
        sr.enabled = false;
        tr.time = -1;
        collider.enabled = false;

        GameOverScreen.GameOver();

        yield return new WaitForSeconds(0.50f);

        Time.timeScale = 0;
    }

}