using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private LayerMask layer;

    private Rigidbody2D _rigidbody;
    private float _jumpForce = 15f;
    private int _coinCount;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        Debug.Log(3);
    }


    private void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 5f, layer) && Input.GetMouseButtonDown(0))
        {
            _rigidbody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            _coinCount++;
            UiManager.instance.ChangeCoin(_coinCount);
        }
        if (collision.transform.CompareTag("Rock"))
        {

            collision.gameObject.SetActive(false);
            _coinCount -= 4;
            if (_coinCount < 0)
            {
                SceneManager.LoadScene(0);
            }
            UiManager.instance.ChangeCoin(_coinCount);
            _animator.SetBool("HelthLoss", true);
            StartCoroutine(HealthLoss());

        }
    }
    IEnumerator HealthLoss()
    {
        yield return new WaitForSeconds(2f);
        _animator.SetBool("HelthLoss", false);


    }
}
