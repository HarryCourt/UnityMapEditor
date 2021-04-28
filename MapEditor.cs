using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditor : MonoBehaviour
{
    // This will probably turn into a list later.
    public GameObject tileObject;

    // Update is called once per frame
    void Update()
    {
        // Boiler-plate code.
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction, Color.blue);

        // Raycast for placing objects.
        if (Physics.Raycast(ray, out hit))
        {
            // to spawn in a tile
            if (Input.GetMouseButtonDown(0))
            {
                // Add a new tile.
                Instantiate(tileObject, new Vector3(Mathf.RoundToInt(hit.point.x), 0, Mathf.RoundToInt(hit.point.z)), Quaternion.identity);
            }
            // to delete a tile
            else if (Input.GetMouseButtonDown(1))
            {
                // juuust making sure :)
                if (hit.transform.tag!= "Grid")
                {
                    Destroy(hit.transform.gameObject);  // Destroy the game tile.
                }
            }
        }
    }
}
