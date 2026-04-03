using UnityEngine;

public class Building : MonoBehaviour
{
    public float width;
    public float height;
    public Transform coinsParent;

    void Awake()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();

        width = boxCollider2D.size.x;
        height = boxCollider2D.size.y;
    }
}
