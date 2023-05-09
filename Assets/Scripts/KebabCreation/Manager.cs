using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public Background background;
    public Plate plate;
    public GameObject plateObject;
    public PauseMenu pauseMenu;
    private Vector2 from;
    public int reqPixelMove = 100;
    private bool isClicked = false;
    private int state = 0;
    private int[] statesMoves = { Screen.width / 2, Screen.width };
    private int plateStateMove = Screen.width / 5;


    void Update()
    {
        if (!isClicked && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            from = Input.touches[0].position;
            isClicked = true;
        }

        if (isClicked && Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                if (Input.touches[0].position.x >= from.x + reqPixelMove)
                {
                    // Swipe right
                    // state--;
                }
                else if (Input.touches[0].position.x <= from.x - reqPixelMove)
                {
                    // Swipe left
                    if (state < statesMoves.Length && !pauseMenu.isPaused())
                    {
                        if (state != 0 || plateObject.activeSelf)
                        {
                            background.Move(new Vector3(-1 * statesMoves[state], 0, 0));
                            if (state == 0)
                            {
                                plate.Move(new Vector3(-1 * plateStateMove, 0, 0));
                            }
                            state++;
                        }
                    }
                }
                isClicked = false;
            }
        }
    }

    public void PlacePlate()
    {
        plateObject.SetActive(true);
    }


}
