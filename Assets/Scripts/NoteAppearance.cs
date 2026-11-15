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

    private uint noteLane;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(NoteType type, uint lane)
    {
        noteLane = lane;
        

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
    public uint NoteLane { get=>noteLane; private set=>noteLane=value; }
}

    
    
