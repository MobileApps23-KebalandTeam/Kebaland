using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public Background background;

    public GameObject plateObject;

    public GameObject[] mainDough;
    public GameObject[] dough;

    public PauseMenu pauseMenu;

    public PlatePanel platePanel;

    public MeatScript[] meatScript;
    public GameObject[] meatObjects;

    public GameObject[] mainExtras;
    public GameObject[] extras;

    // colliders of elements to check if it was clicked
    private BoxCollider[] mainDoughCollider;
    private Vector3[] defaultDoughPosition;

    private BoxCollider plateCollider;
    private BoxCollider[] meatCollider;

    // colliders of elements to check if it was clicked
    private BoxCollider[] mainExtrasCollider;
    private Vector3[] defaultExtrasPosition;

    // start click positions
    private Vector2 fromSwipe, fromCut;
    // flag whether random click and drag was done used to check swiping left
    private bool isClicked = false;

    // id of actually dragged dough to plate
    private int isDraggingDough = -1;
    // id of actually cut meat
    private int isCuttingMeat = -1;
    // object with actually dragged meat
    private MeatScript.FinalMeat draggingMeat = null;
    private int draggingMeatId = -1;
    // id of actually dragged extras to plate
    private int isDraggingExtras = -1;
    // id of actual state (number of scene)
    private int state = 0;

    // distances for changing screens
    public int reqPixelMove = Screen.width / 2;
    public int reqMeatCut = Screen.height / 12;
    private int[] statesMoves = { Screen.width / 2, Screen.width, Screen.width, Screen.width, Screen.width };
    private int plateStateMove = Screen.width / 5;



    void Start()
    {

        // Initialize dough
        defaultDoughPosition = new Vector3[mainDough.Length];
        mainDoughCollider = new BoxCollider[mainDough.Length];
        int i = 0;
        foreach (GameObject obj in mainDough)
        {
            mainDoughCollider[i] = obj.GetComponent<BoxCollider>();
            int hitbox = Screen.width / 5;
            mainDoughCollider[i].size = new Vector3(hitbox, hitbox, 0);
            i++;
        }

        // Initialize plate
        plateCollider = plateObject.GetComponent<BoxCollider>();
        plateCollider.size = new Vector3(Screen.width / 3, Screen.height / 8, 0);

        // Initialize meat
        meatCollider = new BoxCollider[meatObjects.Length];
        int j = 0;
        foreach (GameObject obj in meatObjects)
        {
            meatCollider[j] = obj.GetComponent<BoxCollider>();
            meatCollider[j].size = new Vector3(Screen.width  * 4 / 9, Screen.height * 3 / 5, 0);
            j++;
        }

        // Initialize extras
        defaultExtrasPosition = new Vector3[mainDough.Length];

        mainExtrasCollider = new BoxCollider[mainExtras.Length];
        int k = 0;
        foreach (GameObject obj in mainExtras)
        {
            mainExtrasCollider[k] = obj.GetComponent<BoxCollider>();
            int hitbox = Screen.width / 5;
            mainExtrasCollider[k].size = new Vector3(hitbox, hitbox, 0);
            k++;
        }
    }

    void Update()
    {
        if (Input.touchCount <= 0) return;
        // ON START CLICK
        if (Input.touches[0].phase == TouchPhase.Began)
        {
            if (isDraggingDough >= 0 || isCuttingMeat >= 0 || draggingMeat != null || isDraggingExtras >= 0) return;

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
            if (isDraggingDough >= 0) return;

            if (isCuttingMeat < 0 && state == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (meatCollider[i].bounds.Contains(touchPos))
                    {
                        fromCut = touchPos;
                        isCuttingMeat = i;
                        break;
                    }
                }
            }
            if (isCuttingMeat >= 0) return;

            if (draggingMeat == null && state == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    foreach (MeatScript.FinalMeat meat in meatScript[i].CutList())
                    {
                        if (meat.obj.GetComponent<BoxCollider>().bounds.Contains(touchPos))
                        {
                            draggingMeat = meat;
                            draggingMeatId = i;
                            break;
                        }
                    }
                }
            }
            if (draggingMeat != null) return;

            if (isDraggingExtras < 0 && state == 3)
            {
                for (int i = 0; i < mainExtrasCollider.Length; i++)
                {
                    if (mainExtrasCollider[i].bounds.Contains(touchPos))
                    {
                        defaultExtrasPosition[i] = touchPos;
                        isDraggingExtras = i;
                        extras[i].SetActive(true);
                        break;
                    }
                }
            }
            if (isDraggingExtras >= 0) return;

            if (!isClicked)
            {
                fromSwipe = touchPos;
                isClicked = true;
            }
        }

        // ON END CLICK
        else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
        {
            Vector2 touchPos = Input.touches[0].position;
            if (isDraggingDough >= 0)
            {
                dough[isDraggingDough].SetActive(false);
                dough[isDraggingDough].transform.position = defaultDoughPosition[isDraggingDough];
                if (plateCollider.bounds.Contains(Input.touches[0].position))
                {
                    platePanel.AddIngredient(new PlatePanel.DoughIngredient(isDraggingDough));
                }
                isDraggingDough = -1;
            }
            else if (isCuttingMeat >= 0)
            {
                if (meatCollider[isCuttingMeat].bounds.Contains(touchPos) && touchPos.y - fromCut.y >= reqMeatCut)
                {
                    meatScript[isCuttingMeat].CutMeat(touchPos);
                }
                isCuttingMeat = -1;
            }
            else if (draggingMeat != null)
            {
                if (plateCollider.bounds.Contains(Input.touches[0].position))
                {
                    Destroy(draggingMeat.obj);
                    meatScript[draggingMeatId].RemoveFinalMeat(draggingMeat);
                    platePanel.AddIngredient(new PlatePanel.MeatIngredient(draggingMeatId));
                }
                else
                {
                    draggingMeat.obj.transform.position = draggingMeat.from;
                }
                draggingMeat = null;
                draggingMeatId = -1;
            }
            else if (isDraggingExtras >= 0)
            {
                extras[isDraggingExtras].SetActive(false);
                extras[isDraggingExtras].transform.position = defaultExtrasPosition[isDraggingExtras];
                if (plateCollider.bounds.Contains(Input.touches[0].position))
                {
                    platePanel.AddIngredient(new PlatePanel.ExtraIngredient(isDraggingExtras));
                }
                isDraggingExtras = -1;
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
                                platePanel.Move(new Vector3(-1 * plateStateMove, 0, 0));
                            }
                            if (state == 2)
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    meatScript[i].RemoveRest();
                                }
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
            else if (draggingMeat != null)
            {
                draggingMeat.obj.transform.position = Input.touches[0].position;
            }
            else if (isDraggingExtras >= 0)
            {
                extras[isDraggingExtras].transform.position = Input.touches[0].position;
            }
        }
    }

    public void PlacePlate()
    {
        plateObject.SetActive(true);
    }


}
