using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float cameraSpeed;
    public float cameraRotationSpeed;
    float verticalInput;
    bool switchView;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * verticalInput * cameraSpeed * Time.deltaTime, Space.World);

        if(transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > 18)
        {
            transform.position = new Vector3(18, transform.position.y, transform.position.z);
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            switchView = !switchView;
            if(switchView)
            {
                transform.rotation = Quaternion.Euler(90, 90, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(50, 90, 0);
            }
        }


        /*if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            transform.Rotate(Vector3.right * -1 * Input.GetAxis("Mouse Y") * cameraRotationSpeed * Time.deltaTime, Space.Self);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        if(transform.rotation.eulerAngles.x < 50)
        {
            transform.rotation = Quaternion.Euler(50, 90, 0); 
        }

        if(transform.rotation.eulerAngles.x > 90)
        {
            transform.rotation = Quaternion.Euler(60, 90, 0);
        }*/

    }
}
