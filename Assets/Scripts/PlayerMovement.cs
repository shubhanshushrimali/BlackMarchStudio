using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerPrefab;
    public Camera mainCamera;
    public Vector2Int startPosition = new Vector2Int(0, 0);
    public float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private GameObject playerInstance;

    void Start()
    {
        Vector3 spawnPosition = new Vector3(startPosition.x, 1.5f, startPosition.y);
        playerInstance = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 destination = hit.collider.transform.position;
                Debug.Log($"Clicked position: {destination}");

                if (IsValidMove(destination))
                {
                    StartCoroutine(MovePlayer(destination));
                }
            }
        }
    }

    IEnumerator MovePlayer(Vector3 destination)
    {
        isMoving = true;
        targetPosition = destination;
        float journey = 0f;

        Vector3 startPosition = playerInstance.transform.position;

        while (Vector3.Distance(playerInstance.transform.position, targetPosition) > 0.1f)
        {
            journey += moveSpeed * Time.deltaTime;
            playerInstance.transform.position = Vector3.Lerp(startPosition, targetPosition, journey);
            yield return null;
        }

        playerInstance.transform.position = targetPosition; 
        isMoving = false;
    }

    bool IsValidMove(Vector3 destination)
    {
        if (destination.x < 0 || destination.x >= 10 || destination.z < 0 || destination.z >= 10)
        {
            Debug.Log("Destination out of bounds");
            return false;
        }
        RaycastHit hit;
        if (Physics.Raycast(destination + Vector3.up * 5f, Vector3.down, out hit, 10f))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                Debug.Log("Destination has an obstacle");
                return false;
            }
        }

        return true;
    }
}
