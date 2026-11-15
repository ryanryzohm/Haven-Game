using UnityEngine;

public class MovementDriverScript : MonoBehaviour
{
    private NoteAppearance noteAppearance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        noteAppearance = GetComponent<NoteAppearance>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(noteAppearance.NoteLane)
        {
            case 1:
                transform.position = new Vector3(-15, transform.position.y, transform.position.z);
                break;
            case 2:
                transform.position = new Vector3(-5, transform.position.y, transform.position.z);
                break;
            case 3:
                transform.position = new Vector3(5, transform.position.y, transform.position.z);
                break;
            case 4:
                transform.position = new Vector3(15, transform.position.y, transform.position.z);
                break;
        }
    }
}
