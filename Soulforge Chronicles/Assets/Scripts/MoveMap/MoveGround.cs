using UnityEngine;

public class MoveGround : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        _spriteRenderer.size += new Vector2(10f * Time.deltaTime, 0);
    }
}
