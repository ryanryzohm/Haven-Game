using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementDriver : MonoBehaviour
{
    private NoteAppearance noteAppearance;
    private float yval;
    private float xval;
    private float time;
    private int pressedeval = 0;
    float hitX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        noteAppearance = GetComponent<NoteAppearance>();
        switch (noteAppearance.NoteLane)
        {
            case 1:
                noteAppearance.transform.position = new Vector3(-8, transform.position.y+3, transform.position.z);
                break;
            case 2:
                noteAppearance.transform.position = new Vector3(8, transform.position.y+3, transform.position.z);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        switch (noteAppearance.NoteLane)
        {

            case 1:
                if (pressedeval == 0)
                {
                    xval = -8 + 10f * time; //change it to audio time later
                    yval = -0.26f * Mathf.Pow(xval + 8, 2) + 3;
                    noteAppearance.transform.position = new Vector3(xval, yval, transform.position.z);
                    if (Keyboard.current.fKey.wasPressedThisFrame && noteAppearance.transform.position.x >= -3.75 && noteAppearance.transform.position.x <= -3.25)
                    {
                        pressedeval = 2;
                        yval = -0.26f * Mathf.Pow(xval - 2, 2) + 3; //convert to c# readable code    
                        hitX = xval;
                    }
                    else if (Keyboard.current.fKey.wasPressedThisFrame && noteAppearance.transform.position.x >= -4 && noteAppearance.transform.position.x <= -3)
                    {
                        pressedeval = 1;
                        yval = -3f * Mathf.Pow(xval + 2.2f, 2) + 5   ;
                    }
                }
                else if (pressedeval == 2)
                {
                    xval = -8 + 10f * time; //change it to audio time later
                    yval = -0.26f * Mathf.Pow(xval - 2, 2) + 3;
                    noteAppearance.transform.position = new Vector3(xval, yval, transform.position.z);
                }
                else if (pressedeval == 1)
                {
                    xval = xval += 0.005f * time; //please make it so it just slows the note down instead of yanking it to the other side of the screen

                    yval = -3f * Mathf.Pow(xval + 2.2f, 2) +5;
                    noteAppearance.transform.position = new Vector3(xval, yval, transform.position.z);
                }

                break;
            case 2:
                if (pressedeval == 0)
                {
                    xval = 8 - 10f * time; //change it to audio time later
                    yval = -0.26f * Mathf.Pow(xval - 8, 2) + 3;
                    noteAppearance.transform.position = new Vector3(xval, yval, transform.position.z);
                    if (Keyboard.current.jKey.wasPressedThisFrame && noteAppearance.transform.position.x >= 3.25 && noteAppearance.transform.position.x <= 3.75)
                    {
                        pressedeval = 2;
                        yval = -0.26f * Mathf.Pow(xval + 2, 2) + 3; //convert to c# readable code    
                        hitX = xval;
                    }
                    else if (Keyboard.current.jKey.wasPressedThisFrame && noteAppearance.transform.position.x >= 3 && noteAppearance.transform.position.x <= 4)
                    {
                        pressedeval = 1;
                        yval = -3f * Mathf.Pow(xval - 2.2f, 2) +5;
                    }
                }
                else if (pressedeval == 2)
                {
                    xval = 8 - 10f * time; //change it to audio time later
                    yval = -0.26f * Mathf.Pow(xval + 2, 2) + 3;
                    noteAppearance.transform.position = new Vector3(xval, yval, transform.position.z);
                }
                else if (pressedeval == 1)
                {
                    xval = xval -=0.005f * time; //please make it so it just slows the note down instead of yanking it to the other side of the screen

                    yval = -3f * Mathf.Pow(xval - 2.2f, 2) +5;
                    noteAppearance.transform.position = new Vector3(xval, yval, transform.position.z);
                }
        break;
        default:
                break;
    }

        }
    }
