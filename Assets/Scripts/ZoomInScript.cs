using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Handles the zoom-in and zoom-out functionality for areas of interest in the game
//This script should be attatched to the canvas
//drag areas of interest into the areaOfInterestManager array in the inspector
public class ZoomInScript : MonoBehaviour
{
    public float zoomSpeed = 5f;
    public Camera mainCamera;
    public Button areaOfInterestButton;
    // public float zoomDistance = 5f;
    public Transform cameraTransform;
    private Vector3 origionalPosition;
    private bool zoomInComplete = true;
    private bool zoomOutComplete = true;
    public Button zoomOutButton;
    private Vector3 targetPosition;
    private float origionalSize;
    public float targetSize = 75f;
    public AreaOfInterestManager[] areaOfInterestManager;
    public string AreaName;
    
    [SerializeField] InventoryManager inventoryManager;

    // Calls the zoom-in functionality when an area of interest is clicked
    // This method could be called with a button on an area of interest
    public void ZoomInCall()
    {
        if (cameraTransform.position == origionalPosition){
        Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        areaOfInterestButton = clickedButton;
        zoomInComplete = false;
        }
    }

    // Zooms in to the selected area of interest and activates interactive elements within that area
    private void ZoomIn()
    {
        
        AreaName = areaOfInterestButton.name;
        // zoomOutButton.gameObject.SetActive(true);
        // Debug.Log("Starting zoom in");
        targetPosition = new Vector3(areaOfInterestButton.transform.position.x, areaOfInterestButton.transform.position.y, origionalPosition.z);
        if (!zoomInComplete && areaOfInterestButton != null)
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, zoomSpeed * Time.deltaTime);
            mainCamera.orthographicSize = Vector3.Lerp(new Vector3(mainCamera.orthographicSize, 0, 0), new Vector3(targetSize, 0, 0), zoomSpeed * Time.deltaTime).x;
            // cameraTransform.localScale = Vector3.Lerp(cameraTransform.localScale, areaOfInterestButton.transform.localScale, zoomSpeed * Time.deltaTime);
            if (Vector3.Distance(cameraTransform.position, targetPosition) < 50f)
            {
                areaOfInterestButton.GetComponent<AreaOfInterestManager>().ActivateArea();
            }
            if (Vector3.Distance(cameraTransform.position, targetPosition) < .1f)
            {
                zoomInComplete = true;
                cameraTransform.position = targetPosition;
            }
        }
        if (zoomInComplete)
        {
            zoomOutButton.gameObject.SetActive(true);
        }
    }

    // Calls the zoom-out functionality when an area of interest is clicked
    // This method could be called with a button on an area of interest
    public void ZoomOutCall()
    {
        zoomOutComplete = false;
    }

    // Zooms out from the selected area of interest and deactivates interactive elements within that area
    private void ZoomOut()
    {
        zoomOutButton.gameObject.SetActive(false);
        areaOfInterestButton.GetComponent<AreaOfInterestManager>().DeactivateArea();
        // Debug.Log("Starting zoom out");
        targetPosition = new Vector3(origionalPosition.x, origionalPosition.y, origionalPosition.z);
        if (!zoomOutComplete)
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, zoomSpeed * Time.deltaTime);
            mainCamera.orthographicSize = Vector3.Lerp(new Vector3(mainCamera.orthographicSize, 0, 0), new Vector3(origionalSize, 0, 0), zoomSpeed * Time.deltaTime).x;
            if (Vector3.Distance(cameraTransform.position, targetPosition) < .1f)
            {
                cameraTransform.position = targetPosition;
                // Debug.Log("Zoom in complete");
                zoomOutComplete = true;
                areaOfInterestButton = null;
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zoomInComplete = true;
        zoomOutComplete = true;
        cameraTransform = mainCamera.transform;
        origionalPosition = mainCamera.transform.position;
        origionalSize = mainCamera.orthographicSize;
        zoomOutButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(zoomInComplete == false)
        {
            // Debug.Log("Zooming in");
            ZoomIn();
            // Debug.Log("zoom in complete: " + zoomInComplete);
        }
        if(zoomOutComplete == false)
        {
            // Debug.Log("Zooming out");
            ZoomOut();
            // Debug.Log("zoom out complete: " + zoomOutComplete);
        }

       
    }
}
