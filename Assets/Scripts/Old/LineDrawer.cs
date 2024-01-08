using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UnityLinker;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private Transform players;
    [SerializeField] private GameObject PathParent;
    [SerializeField] private SplineComputer currentSpline;

    Line activeLine;
    Line previousLine;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newLine = Instantiate(linePrefab, PathParent.transform);
            activeLine = newLine.GetComponent<Line>();
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(previousLine != null)
            {
                Destroy(previousLine.gameObject);
            }

            previousLine = activeLine;
            currentSpline = activeLine.splineComputer;
            activeLine = null;
        }
    
        if(activeLine != null)
        {
            //Debug.Log();
            
            // this is worjing somehow
            Vector3 mousePosition = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            activeLine.UpdateLine(mousePosition, PathParent.transform);
            //Debug.Log($"{mousePosition}");
        }
    }

}
