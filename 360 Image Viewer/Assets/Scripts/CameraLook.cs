using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    [SerializeField] private Vector2 Sensitivity;
    float xRot;
    float yRot;

    Vector2 CurrentMousePos;
    Vector3 PrevMousePos;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCamera();
    }


    void UpdateCamera()
    {

        PrevMousePos = CurrentMousePos;
        CurrentMousePos = Input.mousePosition;


        xRot -= (CurrentMousePos.y - PrevMousePos.y) * Time.deltaTime * Sensitivity.x;
        xRot = Mathf.Clamp(xRot, -80.0f, 80.0f);
        yRot += (CurrentMousePos.x - PrevMousePos.x) * Time.deltaTime * Sensitivity.y;

        this.transform.localEulerAngles = new Vector3(xRot, yRot, 0.0f);

        

    }


}
