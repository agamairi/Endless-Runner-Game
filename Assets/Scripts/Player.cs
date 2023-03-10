using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float _speed = 5f;
    private float _jumpHeight = 7.5f;
    public int _diamond = 0;
    private UiManager _uiManager;
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2d;
    [SerializeField]
    private LayerMask _Layermask;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        _boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if (isGrounded() && (Input.touchCount > 0 || Input.GetKeyDown("space")))
        {
            PlayerJump();
        }
        if (this.transform.position.y < -10)
        {
            playerDeath();
        }
    }

    private void PlayerMovement()
    {
        if (_diamond < 6)
        {
            _speed = 5f;
        }
        else if (_diamond > 6 && _diamond < 15)
        {
            _speed = 7f;
        }
        else if (_diamond > 15 && _diamond < 25)
        {
            _speed = 9f;
        }
        else if (_diamond > 25 && _diamond < 35)
        {
            _speed = 6.5f;
        }
        else if (_diamond > 35)
        {
            _speed = 7f;
        }

        transform.Translate(Vector2.right * _speed * Time.deltaTime);

    }
    private void PlayerJump()
    {
        _rigidbody2D.velocity = Vector2.up * _jumpHeight;

    }

    public void addCoins()
    {
        _diamond++;
        _uiManager.UpdateCoinDisplay(_diamond);
    }
    private void playerDeath()
    {
        Destroy(this.gameObject);
        _uiManager.onPlayerDeath(_diamond);
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider2d.bounds.center, _boxCollider2d.bounds.size, 0f, Vector2.down, .1f, _Layermask);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }
}
