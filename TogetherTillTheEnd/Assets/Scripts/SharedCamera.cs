using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedCamera : MonoBehaviour {

    private GameObject warrior;
    private GameObject mage;

    private Vector2 minimumSize;

    private Camera cam;

    // Use this for initialization
    void Start () {
        warrior = FindObjectOfType<Warrior>().gameObject;
        mage = FindObjectOfType<Mage>().gameObject;
        cam = GetComponent<Camera>();
        minimumSize = new Vector2((cam.orthographicSize * cam.aspect), cam.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {
        SetCameraPositionAndSize();
    }

    private void SetCameraPositionAndSize()
    {
        // Get position of players
        Vector3 warriorPos = warrior.transform.position;
        Vector3 magePos = mage.transform.position;

        // Set the camera position as the average between both of those positions
        transform.position = new Vector3(warriorPos.x + magePos.x * 0.5f, warriorPos.y + magePos.y * 0.5f, transform.position.z);

        // Set the size of the camera as the difference between the positions of the players
        float cameraX = Mathf.Abs(warriorPos.x - magePos.x) * 0.5f;
        float cameraY = Mathf.Abs(warriorPos.y - magePos.y) * 0.5f;

        float camSizeX = Mathf.Max(cameraX, minimumSize.x);
        // Set the orthographic size to the maximum of either the computed size in Y,
        // the minimum size possible in Y or the computed size in X times the aspect ratio
        cam.orthographicSize = Mathf.Max(cameraY, minimumSize.y, camSizeX * cam.aspect);
    }
}
