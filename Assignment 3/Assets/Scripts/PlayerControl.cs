using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 5f;
    private float borderY = 5.84f;
    private float borderx = 3f;
    

    [Header("Unity Setup Field")]

    public Rigidbody2D playerRb;
    public Button VictoryButton;
    public Button playButton;
    Vector2 movment;
    private Vector2 position;


    private bool gameOver = false;
    private bool gameStart = false;

    [Header("Unity Sound")]
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip celedretionSound;
    public AudioClip playSound;


    [Header("Particale System")]
    public ParticleSystem chrush;

    void Start()
    {
        position = transform.position;
        playerAudio = GetComponent<AudioSource>();
        playerAudio.Play();

    }


    void Update()
    {
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {

        if (!gameOver && gameStart)
        {

            if (transform.position.x >= borderx)
            {

                transform.position = new Vector3(borderx, transform.position.y, 0);

            }
            if (transform.position.x <= -borderx)
            {
                transform.position = new Vector3(-borderx, transform.position.y, 0);

            }
            if (transform.position.y < -borderY)
            {
                transform.position = new Vector3(transform.position.x, -borderY, 0);

            }

            playerRb.MovePosition(playerRb.position + movment * speed * Time.fixedDeltaTime);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            playerAudio.PlayOneShot(crashSound, 2.0f);
            Instantiate(chrush, transform.position, transform.rotation);
            transform.position = position;
        }


        if (collision.gameObject.CompareTag("Victory"))
        {
            gameOver = true;
            playerAudio.PlayOneShot(celedretionSound, 3.5f);
            VictoryButton.gameObject.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        gameStart = true;
        playerAudio.PlayOneShot(playSound, 3.5f);
        playButton.gameObject.SetActive(false);
    }

}
