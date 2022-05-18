using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePlacer : MonoBehaviour
{
    private GameObject obj;
    private GameObject bush_one;
    private GameObject bush_two;
    private GameObject bush_three;
    private GameObject bush_four;
    private int curr_bush;
    private Vector3[] positions;
    private int curr_vertex;
    private Mesh[] mesh = new Mesh[6];

    // Start is called before the first frame update
    void Start()
    {
        curr_vertex = 0;
        curr_bush = 0;
        bush_one = GameObject.Find("P_Bush01");
        bush_one.transform.localScale = new Vector3(0, 0, 0);
        bush_two = GameObject.Find("P_Bush02");
        bush_two.transform.localScale = new Vector3(0, 0, 0);
        bush_three = GameObject.Find("P_Bush03");
        bush_three.transform.localScale = new Vector3(0, 0, 0);
        bush_four = GameObject.Find("P_Bush04");
        bush_four.transform.localScale = new Vector3(0, 0, 0);

        positions = new Vector3[8];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {

            print(transform.position);
            obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.localScale -= new Vector3(0.75f, 0.75f, 0.75f);
            obj.transform.position = transform.position;
            positions[curr_vertex] = transform.position;
            obj.active = false;
            curr_vertex += 1;
        }

        if (Input.GetKeyDown(KeyCode.J)) {
            float minx = int.MaxValue;
            float miny = int.MaxValue;
            float minz = int.MaxValue;
            float maxx = int.MinValue;
            float maxy = int.MinValue;
            float maxz = int.MinValue;
            for (int i = 0; i < curr_vertex; i++) {
                float x = positions[i][0];
                float y = positions[i][1];
                float z = positions[i][2];

                if (x < minx) {
                    minx = x;
                } 
                if (x > maxx) {
                    maxx = x;
                }
                if (y < miny) {
                    miny = y;
                } 
                if (y > maxy) {
                    maxy = y;
                }
                if (z < minz) {
                    minz = z;
                } 
                if (z > maxz) {
                    maxz = z;
                }
            }

            float widthx = maxx - minx;
            float widthy = maxy - miny;
            float widthz = maxz - minz;

            Vector3 pos = new Vector3(minx + (0.5f * widthx), miny - (0.5f * widthy), minz + (0.5f * widthz));

            //obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //obj.transform.localScale = Vector3.Scale(obj.transform.localScale, new Vector3(widthx, widthy, widthz));
            //obj.transform.position = pos;
            if (curr_bush == 0) {
                bush_one.transform.localScale = new Vector3(widthx, widthy, widthz);
                bush_one.transform.position = pos;
            } else if (curr_bush == 1) {
                bush_two.transform.localScale = new Vector3(widthx, widthy, widthz);
                bush_two.transform.position = pos;
            } else if (curr_bush == 2) {
                bush_three.transform.localScale = new Vector3(widthx, widthy, widthz);
                bush_three.transform.position = pos;
            } else if (curr_bush == 3) {
                bush_four.transform.localScale = new Vector3(widthx, widthy, widthz);
                bush_four.transform.position = pos;
            } else {
                curr_bush = -1;
            }
            curr_bush += 1;
            curr_vertex = 0;
        }

    }
}
