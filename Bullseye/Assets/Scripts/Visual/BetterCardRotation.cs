﻿using UnityEngine;
using System.Collections;

/// <summary>
/// This script should be attached to the card game object to display card`s rotation correctly.
/// </summary>

[ExecuteInEditMode]
public class BetterCardRotation : MonoBehaviour {

    // parent game object for all the card face graphics
    public RectTransform CardFront;

    // parent game object for all the card back graphics
    public RectTransform CardBack;

    // an empty game object that is placed a bit above the face of the card, in the center of the card
    public Transform targetFacePoint;

    // 3d collider attached to the card (2d colliders like BoxCollider2D won`t work in this case)
    public Collider col;

    // if this is true, our players currently see the card Back
    private bool showingBack = false;

    public GameObject gameObjectUnderCamera;

	// Update is called once per frame
	void Update () 
    {
        // Raycast from Camera to a target point on the face of the card
        // If it passes through the card`s collider, we should show the back of the card
        RaycastHit[] hits;
        hits = Physics.RaycastAll(origin: gameObjectUnderCamera.transform.position, direction: (-gameObjectUnderCamera.transform.position + targetFacePoint.position).normalized, maxDistance: (-gameObjectUnderCamera.transform.position + targetFacePoint.position).magnitude);
        bool passedThroughColliderOnCard = false;
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (hit.collider != null)
            {
                if (hit.collider == col)
                {
                    passedThroughColliderOnCard = true;
                }
            }
        }
            
        //    foreach (RaycastHit h in hits)
        //{
            //if (hits != null)
            //{
            //    //if (h.collider == col)
            //    //{

            //    //}
            //    //passedThroughColliderOnCard = true;
            //}
            
        //}
        //Debug.Log("TotalHits: " + hits.Length); 
        if (passedThroughColliderOnCard!= showingBack)
        {
            // something changed
            showingBack = passedThroughColliderOnCard;
            if (showingBack)
            {
                // show the back side
                CardFront.gameObject.SetActive(false);
                CardBack.gameObject.SetActive(true);
            }
            else
            {
                // show the front side
                CardFront.gameObject.SetActive(true);
                CardBack.gameObject.SetActive(false);
            }

        }

	}
}
