using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public Background background;
    public Plate plate;
    public GameObject plateObject;
    public GameObject[] mainDough;
    public GameObject[] dough;
    public PauseMenu pauseMenu;

    // colliders of dough element to check if it was clicked
    private BoxCollider[] mainDoughCollider;
    private Vector3[] defaultDoughPosition;

    // start click positions
    private Vector2 fromSwipe;
    // flag whether random click and drag was done used to check swiping left
    private bool isClicked = false;

    // id of actually dragged dough to plate
    private int isDraggingDough = -1;
    // id of actual state (number of scene)
    private int state = 0;

    // distances for changing screens
    public int reqPixelMove = Screen.width / 2;
    private int[] statesMoves = { Screen.width / 2, Screen.width };
    private int plateStateMove = Screen.width / 5;


    void Start()
    {
        int i = 0;
        mainDoughCollider = new BoxCollider[mainDough.Length];
        defaultDoughPosition = new Vector3[mainDough.Length];
        foreach (GameObject obj in mainDough)
        {
            mainDoughCollider[i] = obj.GetComponent<BoxCollider>();
            int hitbox = Screen.width / 5;
            mainDoughCollider[i].size = new Vector3(hitbox, hitbox, 0);
            i++;
        }
    }

    void Update()
    {
        if (Input.touchCount <= 0) return;
        // ON START CLICK
        if (Input.touches[0].phase == TouchPhase.Began)
        {
            Vector2 touchPos = Input.touches[0].position;
            if (isDraggingDough < 0 && state == 1)
            {
                for (int i = 0; i < mainDoughCollider.Length; i++)
                {
                    if (mainDoughCollider[i].bounds.Contains(touchPos))
                    {
                        defaultDoughPosition[i] = touchPos;
                        isDraggingDough = i;
                        dough[i].SetActive(true);
                        break;
                    }
                }
            }
            if (isDraggingDough < 0 && !isClicked)
            {
                fromSwipe = touchPos;
                isClicked = true;
            }
        }

        // ON END CLICK
        else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
        {
            if (isDraggingDough >= 0)
            {
                dough[isDraggingDough].SetActive(false);
                dough[isDraggingDough].transform.position = defaultDoughPosition[isDraggingDough];
                // TODO check if end was on plate and if so then add dough to plate
                isDraggingDough = -1;
            }
            else if (isClicked)
            {
                // Swipe right
                if (Input.touches[0].position.x >= fromSwipe.x + reqPixelMove)
                {
                    // state--;
                }
                
                // Swipe left
                else if (Input.touches[0].position.x <= fromSwipe.x - reqPixelMove)
                {
                    if (state < statesMoves.Length && !pauseMenu.isPaused())
                    {
                        if (isDraggingDough < 0 && (state != 0 || plateObject.activeSelf))
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

        // ON ANY OTHER CLICK
        else
        {
            if (isDraggingDough >= 0)
            {
                dough[isDraggingDough].transform.position = Input.touches[0].position;
            }
        }
    }

    public void PlacePlate()
    {
        plateObject.SetActive(true);
    }


}
