using UnityEngine;

public class Wall : MonoBehaviour
{
    private const float Widht = 1f;
    
    [SerializeField] private BoxCollider2D _upperCollider;
    [SerializeField] private BoxCollider2D _lowerCollider;
    [SerializeField] private BoxCollider2D _scoringArea;

    public void SetColliderHeight(int upperHeight, int scoringHeight, int lowerHeight)
    {
        _upperCollider.transform.localPosition = new Vector2(0f, upperHeight * 0.5f);
        _upperCollider.transform.localScale = new Vector2(Widht, upperHeight);

        _scoringArea.transform.localPosition = new Vector2(0f, upperHeight + scoringHeight * 0.5f);
        _scoringArea.transform.localScale = new Vector2(Widht, scoringHeight);

        _lowerCollider.transform.localPosition = new Vector2(0f, upperHeight + scoringHeight + lowerHeight * 0.5f);
        _lowerCollider.transform.localScale = new Vector2(Widht, lowerHeight);
    }
}

