using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Subject
{
    public float CurrentScore
    {
        get { return score; }
    }

    private float moveSpeed = 5;
    public Rigidbody2D player;
    private HUDController _hudController;
    private Vector2 moveInput;
    private int lives = 3;
    [SerializeField] private int score = 0;
    void Awake()
    {
        _hudController =
        gameObject.AddComponent<HUDController>();
    }
        // Start is called before the first frame update
        void Start()
    {

    }

    void OnEnable()
    {
        if (_hudController)
            Attach(_hudController);
    }
        // Update is called once per frame
        void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
        player.velocity = moveInput * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            lives--;
            score += 100; 
            NotifyObservers();
        }
    }
}
