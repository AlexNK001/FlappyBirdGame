using UnityEngine;

public class Wall : MonoBehaviour
{
    private const float Width = 1f;
    private const float Half = 0.5f;
    
    [SerializeField] private BoxCollider2D _upperCollider;
    [SerializeField] private BoxCollider2D _lowerCollider;
    [SerializeField] private BoxCollider2D _scoringArea;

    public void SetColliderHeight(int upperHeight, int scoringHeight, int lowerHeight)
    {
        _upperCollider.transform.localPosition = new Vector2(0f, upperHeight * Half);
        _upperCollider.transform.localScale = new Vector2(Width, upperHeight);

        _scoringArea.transform.localPosition = new Vector2(0f, upperHeight + scoringHeight * Half);
        _scoringArea.transform.localScale = new Vector2(Width, scoringHeight);

        _lowerCollider.transform.localPosition = new Vector2(0f, upperHeight + scoringHeight + lowerHeight * Half);
        _lowerCollider.transform.localScale = new Vector2(Width, lowerHeight);
    }
}