using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnLook : MonoBehaviour

{
    public Camera playerCamera; // Assign the player's camera in the Inspector
    public GameObject targetObject; // Assign the object to activate
    public float raycastDistance = 10f;
    private bool isObjectActive = false;

    void Update()
    {
        if (playerCamera == null || targetObject == null)
        {
            Debug.LogWarning("Camera or Target Object not assigned!");
            return;
        }

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance) && hit.collider.gameObject == targetObject)
        {
            targetObject.GetComponent<Tremble>().timeToTremble = true; //
            isObjectActive = true;
            Debug.Log("Activated: " + targetObject.name);
        }
        else if (isObjectActive)
        {
            targetObject.GetComponent<Tremble>().timeToTremble = false;
            isObjectActive = false;
            Debug.Log("Deactivated: " + targetObject.name);
        }
    }
}
