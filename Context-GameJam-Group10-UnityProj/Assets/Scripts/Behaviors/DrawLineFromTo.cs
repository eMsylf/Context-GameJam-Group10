using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLineFromTo : MonoBehaviour {
    public Transform[] Points;
    public List<Vector3> PointsV3;

    public Vector3[] PointsV3Array;

    public Color LineColor;

    public LineRenderer LineRenderer;

    void Start() {

    }

    private void OnDrawGizmos() {
        if (LineRenderer == null) {
            LineRenderer = GetComponent<LineRenderer>();
        }
        LineRenderer.positionCount = Points.Length;
        

        for (int i = 0; i < Points.Length; i++) {
            PointsV3.Add(Points[i].position); // Hier ging het fout
        }

        PointsV3Array = PointsV3.ToArray();

        LineRenderer.SetPositions(PointsV3Array);
    }


    void Update() {

    }
}
