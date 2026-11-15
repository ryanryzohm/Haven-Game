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
    void SpawnNote(NoteType type)
    {
        NoteAppearance note = Instantiate(NotePrefab);
        note.Initialize(type);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // make this load charts //
    }
}
