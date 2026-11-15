using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;


public class MovementDriver : MonoBehaviour
{
    static int ScoreCounter;
    private NoteAppearance noteAppearance;
    private double yval;
    private double xval;
    private double time;
    private int pressedeval = 0;
    double hitX;
    public double slowMovement;
    private double spawnTime;
    private double prevTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTime = AudioSettings.dspTime;

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
        time += (AudioSettings.dspTime - spawnTime) / slowMovement - prevTime - noteAppearance.NoteBeat;

        switch (noteAppearance.NoteLane)
        {

            case 1:
                if (pressedeval == 0)
                {
                    xval = -8 + 10d*time; //change it to audio time later
                    yval = -0.26d * Mathf.Pow((float)xval + 8, 2) + 3;
                    noteAppearance.transform.position = new Vector3((float)xval, (float)yval, transform.position.z);
                    if (Keyboard.current.fKey.wasPressedThisFrame && noteAppearance.transform.position.x >= -3.75 && noteAppearance.transform.position.x <= -3.25)
                    {
                        ScoreCounter += 2;
                        pressedeval = 2;
                        yval = -0.26f * Mathf.Pow((float)xval - 2, 2) + 3; //convert to c# readable code    
                        hitX = xval;
                    }
                    else if (Keyboard.current.fKey.wasPressedThisFrame && noteAppearance.transform.position.x >= -4 && noteAppearance.transform.position.x <= -3)
                    {
                        ScoreCounter += 1;
                        pressedeval = 1;
                        yval = -3f * Mathf.Pow((float)xval + 2.2f, 2) + 5   ;
                    }
                }
                else if (pressedeval == 2)
                {
                    xval = -8 + 10d * time;
                    yval = -0.26f * Mathf.Pow((float)xval - 2, 2) + 3;
                    noteAppearance.transform.position = new Vector3((float)xval, (float)yval, transform.position.z);
                }
                else if (pressedeval == 1)
                {
                    xval = xval += 0.035f * time; //please make it so it just slows the note down instead of yanking it to the other side of the screen

                    yval = -3f * Mathf.Pow((float)xval + 2.2f, 2) +5;
                    noteAppearance.transform.position = new Vector3((float)xval, (float)yval, transform.position.z);
                }

                break;
            case 2:
                if (pressedeval == 0)
                {
                    xval =  8-10d*time; //change it to audio time later
                    yval = -0.26f * Mathf.Pow((float)xval - 8, 2) + 3;
                    noteAppearance.transform.position = new Vector3((float)xval, (float)yval, transform.position.z);
                    if (Keyboard.current.jKey.wasPressedThisFrame && noteAppearance.transform.position.x >= 3.25 && noteAppearance.transform.position.x <= 3.75)
                    {
                        ScoreCounter += 2;
                        pressedeval = 2;
                        yval = -0.26f * Mathf.Pow((float)xval + 2, 2) + 3; //convert to c# readable code    
                        hitX = xval;
                    }
                    else if (Keyboard.current.jKey.wasPressedThisFrame && noteAppearance.transform.position.x >= 3 && noteAppearance.transform.position.x <= 4)
                    {
                        ScoreCounter += 1;
                        pressedeval = 1;
                        yval = -3f * Mathf.Pow((float)xval - 2.2f, 2) +5;
                    }
                }
                else if (pressedeval == 2)
                {
                    xval = 8 - 10d * time; //change it to audio time later
                    yval = -0.26f * Mathf.Pow((float)xval + 2, 2) + 3;
                    noteAppearance.transform.position = new Vector3((float)xval, (float)yval, transform.position.z);
                }
                else if (pressedeval == 1)
                {
                    xval = xval -=0.035f * time; //please make it so it just slows the note down instead of yanking it to the other side of the screen

                    yval = -3f * Mathf.Pow((float)xval - 2.2f, 2) +5;
                    noteAppearance.transform.position = new Vector3((float)xval, (float)yval, transform.position.z);
                }
        break;
        default:
                break;
    }
        prevTime = time;

        }
    }
