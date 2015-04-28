using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MouseInput : MonoBehaviour {

    public Vector2 inputWorldPosition;
    public GameObject window, build;
    private Ray2D ray;
    public Collider2D clickedOn;
    public Camera cam;
    public bool comradery, move;
    public GameObject comrade1, comrade2, buildingToMove;

    public CanvasGroup resultCG;
    public Text result;

	void Start () {
        cam = GetComponent<Camera>();	
	}

    public void startComradery()
    {
        comradery = true;
    }

    public void windowComradery()
    {
        comradery = true;
        comrade1 = window.GetComponentInChildren<windowValues>().clickedByGO;
    }

    public void moveBuilding()
    {
        move = true;
        buildingToMove = window.GetComponentInChildren<windowValues>().clickedByGO;
    }


	void Update () {
        if (!comradery && !move)
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
            resultCG.alpha = 1;
            resultCG.interactable = true;
            resultCG.blocksRaycasts = true;

            if(!comrade1)
            {
                result.text = "Choose first comrade.";
            }

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
                comradery = false;

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
            float xPos, yPos;
            xPos = cam.ScreenToWorldPoint(Input.mousePosition).x;
            yPos = cam.ScreenToWorldPoint(Input.mousePosition).y;

            resultCG.alpha = 1;
            result.text = "Click where you want the building to be moved.";

            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                buildingToMove.GetComponent<Collider2D>().enabled = false;

                if (!Physics2D.OverlapArea(new Vector2(xPos - 0.6F, yPos - 0.6F),
                 new Vector2(xPos + 0.6F, yPos + 0.6F)) )
                {
                    buildingToMove.transform.position = new Vector3(xPos, yPos, 0);

                    if (Input.GetMouseButtonDown(0))
                    {
                        buildingToMove.transform.position = new Vector3(xPos, yPos, 0);
                        move = false;
                        result.text = "Succesfully moved building";
                        buildingToMove.GetComponent<Collider2D>().enabled = true;
                        if (resultCG.alpha != 0)
                            Invoke("hideResult", 1.5F);
                    }
                }

            }
            
        }

	}

    void hideResult()
    {
        result.text = "";
        resultCG.alpha = 0;
        resultCG.interactable = false;
        resultCG.blocksRaycasts = false;
    }

}
