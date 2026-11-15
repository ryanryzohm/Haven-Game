using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;

public class SpawnNotes : MonoBehaviour
{
    [Serializable]
    public struct Note
    {
        float hitBeat;
        NoteType noteType;
    }
    public List<Note> LoadedChart;

    public void LoadChart()
    {
        // implement later //
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
        SpawnNote(NoteType.Release, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // make this load charts //
    }
}
