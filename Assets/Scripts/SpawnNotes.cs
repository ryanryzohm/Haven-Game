using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnNotes : MonoBehaviour
{
    public struct Note
    {
        float spawnTime;
        float hitTime;
    }
    public NoteAppearance NotePrefab;
    void SpawnNote(NoteType type, uint lane)
    {
        NoteAppearance note = Instantiate(NotePrefab);
        note.Initialize(type, lane);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnNote(NoteType.Tap, 2);
        SpawnNote(NoteType.Untimed, 3);
        SpawnNote(NoteType.Hold, 4);
        SpawnNote(NoteType.Release, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // make this load charts //
    }
}
