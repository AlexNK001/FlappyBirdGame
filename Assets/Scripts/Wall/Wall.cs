using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Collider2D _upperCollider;
    [SerializeField] private Collider2D _lowerCollider;
    [SerializeField] private Collider2D _scoringArea;

    public void SetColliderSize(int upperSize, int scoringSize, int lowerSize)
    {
        _upperCollider.transform.localPosition = new Vector2(0f, upperSize * 0.5f);
        _upperCollider.transform.localScale = new Vector2(1f, upperSize);

        _scoringArea.transform.localPosition = new Vector2(0f, upperSize + scoringSize * 0.5f);
        _scoringArea.transform.localScale = new Vector2(1f, scoringSize);

        _lowerCollider.transform.localPosition = new Vector2(0f, upperSize + scoringSize + lowerSize * 0.5f);
        _lowerCollider.transform.localScale = new Vector2(1f, lowerSize);
    }
}

