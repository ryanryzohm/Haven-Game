using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;
using System.Text.Json;

public class SpawnNotes : MonoBehaviour
{
    [Serializable]
    public struct Note
    {
        public uint Lane { get; set; }
        public float HitBeat { get; set; }
        public NoteType NoteType { get; set; }
    }
    public List<Note> LoadedChart;

    public void LoadChart(TextAsset chartJson)
    {
        LoadedChart = JsonSerializer.Deserialize<List<Note>>(chartJson.text);
        foreach (Note note in LoadedChart)
        {
            Debug.Log(note.NoteType);
        }
    }

    public NoteAppearance NotePrefab;
    void SpawnNote(Note note)
    {
        float beat = note.HitBeat;
        NoteType type = note.NoteType;
        uint lane = note.Lane;
        NoteAppearance noteAppearance = Instantiate(NotePrefab);  // instantiate note
        noteAppearance.Initialize(beat, type, lane);  // initialize note
    }

    void Awake()
    {

           Debug.Log(chartJson);
        LoadChart(chartJson); // this should load the current chart //
        foreach (Note note in LoadedChart)
        {
            SpawnNote(note);
        }
    }    TextAsset chartJson = Resources.Load<TextAsset>("main_chart");
 

    // Update is called once per frame
    void Update()
    {
        // this should dynamically load the notes based on a spawn window //
    }
}
