using UnityEngine;

public enum NoteType
{
    Tap,
    Hold,
    Untimed,
    Release
}

[RequireComponent(typeof(SpriteRenderer))]
public class NoteAppearance : MonoBehaviour
{
    public Sprite TapSprite;
    public Sprite HoldSprite;
    public Sprite UntimedSprite;
    public Sprite ReleaseSprite;

    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(NoteType type)
    {
        switch (type)
        {
            case NoteType.Tap:
                spriteRenderer.sprite = TapSprite;
                break;
            case NoteType.Hold:
                spriteRenderer.sprite = HoldSprite;
                break;
            case NoteType.Untimed:
                spriteRenderer.sprite = UntimedSprite;
                break;
            case NoteType.Release:
                spriteRenderer.sprite = ReleaseSprite;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
