using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MouseInput : MonoBehaviour {

    public Vector2 inputWorldPosition;
    public GameObject window, build;
    private Ray2D ray;
    public Collider2D clickedOn;
    public Camera cam;
    public bool comradery, move, winMove, winComradery;
    public GameObject comrade1, comrade2, buildingToMove;

    public CanvasGroup resultCG;
    public Text result, ComraderyButtonText, moveButtonText;

	void Start () {
        cam = GetComponent<Camera>();	
	}

    public void startComradery()
    {
        if(!winMove)
        { 
            if (comradery || winComradery)
                stopComradery();
            else
            {
                comradery = true;
                changeText();
                stopMoving();
            }
        }
    }

    public void windowComradery()
    {
        if (!move && !comradery)
        { 
            stopMoving();
            stopComradery();
            winComradery = true;
            comrade1 = window.GetComponentInChildren<windowValues>().clickedByGO;
        }
    }

    public void windowMoveBuilding()
    {
        if (!move && !comradery)
        { 
            stopComradery();
            stopMoving();
            winMove = true;
            buildingToMove = window.GetComponentInChildren<windowValues>().clickedByGO;
        }
    }

    public void moveBuilding()
    {
        if (!winMove && !winComradery)
        {
            if (move)
                stopMoving();
            else
            {
                stopComradery();
                move = true;
            }
        }
    }


	void Update () {
        if (!comradery && !move && !winMove && !winComradery)
        {
            if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                if (Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition)))
                {
                    clickedOn = Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition));
                    if (window.GetComponent<hide>().hideTab == true)
                        window.GetComponent<hide>().toggle();

                    window.GetComponentInChildren<windowValues>().clicked(clickedOn.gameObject);
                }
                else
                {
                    clickedOn = null;
                    if (window.GetComponent<hide>().hideTab == false)
                        window.GetComponent<hide>().toggle();
                }

                if (build.GetComponent<hide>().hideTab == false)
                    build.GetComponent<hide>().toggle();

            }

            if (Input.GetMouseButtonDown(1))
            {
                if (window.GetComponent<hide>().hideTab == false)
                    window.GetComponent<hide>().toggle();
                if (build.GetComponent<hide>().hideTab == false)
                    build.GetComponent<hide>().toggle();
            }
        }
        else if(comradery)
        {
            ComraderyButtonText.text = "Cancel Comradery";

            resultCG.alpha = 1;
            resultCG.interactable = true;
            resultCG.blocksRaycasts = true;

            if (comrade1 && !comrade2)
            {
                result.text = "Choose second comrade.";
            }
            if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                if (Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition)))
                {
                    clickedOn = Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition));

                    if(comrade1 && !comrade2)
                        comrade2 = clickedOn.gameObject;

                    if (!comrade1)
                        comrade1 = clickedOn.gameObject;
                }
                else
                {
                    clickedOn = null;
                }

            }

            if(comrade1 && comrade2)
            {

                if (!GameResources.instance.isLinkable(comrade1.GetComponent<IdManager>().buildingIndex))
                {
                    result.text = "The building already has a comrade.";
                }
                else if (!GameResources.instance.canLink(comrade1.GetComponent<IdManager>().buildingIndex, comrade2.GetComponent<IdManager>().buildingIndex))
                {
                    result.text = "One of the buildings you chose cannot have comrades.";
                }
                else if (GameResources.instance.canLink(comrade1.GetComponent<IdManager>().buildingIndex, comrade2.GetComponent<IdManager>().buildingIndex)
                    && GameResources.instance.isLinkable(comrade1.GetComponent<IdManager>().buildingIndex))
                {
                    result.text = "Comradery Succesfuly established!";
                    GameResources.instance.linkBuildings(comrade1.GetComponent<IdManager>().buildingIndex, comrade2.GetComponent<IdManager>().buildingIndex);

                    comrade1.GetComponent<lineRendererFunctionality>().updateTarget(comrade2);

                    if (window.GetComponentInChildren<windowValues>().clickedByGO)
                        window.GetComponentInChildren<windowValues>().clicked(comrade1);
                   
                }
                if (comrade1 == comrade2)
                {
                    result.text = "You must choose different comrades!";
                }

                

                comrade1 = comrade2 = null;

                Invoke("changeText", 1.5F);
            }

        }

        else if (winComradery)
        {
            ComraderyButtonText.text = "Cancel Comradery";

            resultCG.alpha = 1;
            resultCG.interactable = true;
            resultCG.blocksRaycasts = true;

            if (comrade1 && !comrade2)
            {
                result.text = "Choose second comrade.";
            }

            if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                if (Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition)))
                {
                    clickedOn = Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition));

                    if (comrade1 && !comrade2)
                        comrade2 = clickedOn.gameObject;
                }
                else
                {
                    clickedOn = null;
                }

            }

            if (comrade1 && comrade2)
            {

                if (!GameResources.instance.isLinkable(comrade1.GetComponent<IdManager>().buildingIndex))
                {
                    result.text = "The building already has a comrade.";
                }
                else if (!GameResources.instance.canLink(comrade1.GetComponent<IdManager>().buildingIndex, comrade2.GetComponent<IdManager>().buildingIndex))
                {
                    result.text = "One of the buildings you chose cannot have comrades.";
                }
                else if (GameResources.instance.canLink(comrade1.GetComponent<IdManager>().buildingIndex, comrade2.GetComponent<IdManager>().buildingIndex)
                    && GameResources.instance.isLinkable(comrade1.GetComponent<IdManager>().buildingIndex))
                {
                    result.text = "Comradery Succesfuly established!";
                    GameResources.instance.linkBuildings(comrade1.GetComponent<IdManager>().buildingIndex, comrade2.GetComponent<IdManager>().buildingIndex);
                    winComradery = false;
                    ComraderyButtonText.text = "Establish Comradery";
                    comrade1.GetComponent<lineRendererFunctionality>().updateTarget(comrade2);
                    window.GetComponentInChildren<windowValues>().clicked(comrade1);
                }


                if (comrade1 == comrade2)
                {
                    result.text = "You must choose different comrades!";
                }

                if (resultCG.alpha != 0)
                    Invoke("hideResult", 1.5F);

                comrade1 = comrade2 = null;
            }

        }

        else if (move)
        {
            moveButtonText.text = "Stop Moving";

            float xPos, yPos;
            xPos = cam.ScreenToWorldPoint(Input.mousePosition).x;
            yPos = cam.ScreenToWorldPoint(Input.mousePosition).y;

            resultCG.alpha = 1;
            if (!buildingToMove)
            {
                result.text = "Click on the building you want to move and hold the mouse button down.";

                if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    if (Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition)))
                    {
                        clickedOn = Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition));
                        buildingToMove = clickedOn.gameObject;
                    }
                    else
                    {
                        clickedOn = null;
                    }

                }
            }
            
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && buildingToMove)
            {
                result.text = "Drag the mouse to where you want the building to be moved and release the mouse button.";
                buildingToMove.GetComponent<Collider2D>().enabled = false;

                if (!Physics2D.OverlapArea(new Vector2(xPos - 0.6F, yPos - 0.6F),
                 new Vector2(xPos + 0.6F, yPos + 0.6F)) )
                {
                    buildingToMove.transform.position = new Vector3(xPos, yPos, 0);

                    if (Input.GetMouseButtonUp(0))
                    {
                        buildingToMove.transform.position = new Vector3(xPos, yPos, 0);
                        result.text = "Succesfully moved building";
                        buildingToMove.GetComponent<Collider2D>().enabled = true;
                        buildingToMove = null;
                    }
                }

            }
            
        }
        else if (winMove)
        {
            moveButtonText.text = "Stop Moving";
            result.text = "Click where you want the building to be moved.";

            float xPos, yPos;
            xPos = cam.ScreenToWorldPoint(Input.mousePosition).x;
            yPos = cam.ScreenToWorldPoint(Input.mousePosition).y;

            resultCG.alpha = 1;
            

            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                buildingToMove.GetComponent<Collider2D>().enabled = false;

                if (!Physics2D.OverlapArea(new Vector2(xPos - 0.6F, yPos - 0.6F),
                 new Vector2(xPos + 0.6F, yPos + 0.6F)))
                {
                    buildingToMove.transform.position = new Vector3(xPos, yPos, 0);

                    if (Input.GetMouseButtonDown(0))
                    {
                        buildingToMove.transform.position = new Vector3(xPos, yPos, 0);
                        result.text = "Succesfully moved building";
                        winMove = false;
                        moveButtonText.text = "Move Building";
                        buildingToMove.GetComponent<Collider2D>().enabled = true;
                        buildingToMove = null;
                        if (resultCG.alpha != 0)
                            Invoke("hideResult", 1.5F);
                    }
                }

            }

        }

	}

    public void changeText()
    {
        if (comradery)
        {
            result.text = "Choose first comrade.";
        }
    }

    public void stopComradery()
    {
        comradery = false;
        winComradery = false;
        comrade1 = comrade2 = null;
        if (resultCG.alpha != 0)
            Invoke("hideResult", 1.5F);
        ComraderyButtonText.text = "Establish Comradery";
    }

    public void stopMoving()
    {
        move = false;
        winMove = false;
        buildingToMove = null;
        Invoke("hideResult", 1.5F);
        moveButtonText.text = "Move Building";
    }

    void hideResult()
    {
        if(!comradery && !move)
        { 
            result.text = "";
            resultCG.alpha = 0;
            resultCG.interactable = false;
            resultCG.blocksRaycasts = false;
        }
    }

}
