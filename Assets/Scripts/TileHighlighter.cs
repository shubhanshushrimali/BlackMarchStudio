using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileHighlighter : MonoBehaviour
{
    public Camera mainCamera;
    public Text positionText;

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            TileInfo tileInfo = hit.transform.GetComponent<TileInfo>();
            if (tileInfo != null)
            {
                positionText.text = $"Tile: ({tileInfo.x}, {tileInfo.y})";
            }
        }
    }

}
