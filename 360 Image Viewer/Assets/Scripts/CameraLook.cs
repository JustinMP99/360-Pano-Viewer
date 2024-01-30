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

    [SerializeField]float holdTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        PrevMousePos = CurrentMousePos;
        CurrentMousePos = Input.mousePosition;
        if (Input.GetKey(KeyCode.Mouse0))
        {

            
            if (holdTimer >= 2.0f)
            {
                Debug.Log("Holding");
                UpdateCamera();

            }
            else
            {
                holdTimer += 0.10f ;
            }

        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log("Released");
            
            holdTimer = 0.0f;
        }


    }


    void UpdateCamera()
    {

      
        xRot -= (CurrentMousePos.y - PrevMousePos.y) * Time.deltaTime * Sensitivity.x;
        xRot = Mathf.Clamp(xRot, -80.0f, 80.0f);
        yRot += (CurrentMousePos.x - PrevMousePos.x) * Time.deltaTime * Sensitivity.y;

        this.transform.localEulerAngles = new Vector3(xRot, yRot, 0.0f);

      
    }


}
