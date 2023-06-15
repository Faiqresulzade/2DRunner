using System.Collections;
using UnityEngine;

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
        if (Physics2D.Raycast(transform.position, Vector2.down, 5f, layer) && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Coin"))
        {
            _coinCount++;
            UiManager.instance.ChangeCoin(_coinCount);
            collision.gameObject.SetActive(false);
        }
        if (collision.transform.CompareTag("Rock"))
        {

            _coinCount -= 4;
            UiManager.instance.ChangeCoin(_coinCount);
            _animator.SetBool("HelthLoss", true);
            StartCoroutine(HealthLoss());
            collision.gameObject.SetActive(false);

        }
    }
    IEnumerator HealthLoss()
    {
        yield return new WaitForSeconds(2f);
        _animator.SetBool("HelthLoss", false);


    }
}
