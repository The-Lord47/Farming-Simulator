using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class playerControl : MonoBehaviour
{
    [SerializeField] GameObject youngWheat;
    [SerializeField] GameObject wheatCut;
    [SerializeField] AudioSource _sfx;
    [SerializeField] AudioClip sowingSeedsSFX;
    [SerializeField] AudioClip harvestWheatSFX;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.CompareTag("Tractor"))
        {
            moveUnit();
        }
        else if (Input.GetMouseButtonDown(1) && transform.CompareTag("Harvester"))
        {
            moveUnit();
        }

        
    }

    void moveUnit()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;

        if (Physics.Raycast(_ray, out _hit))
        {
            GetComponent<NavMeshAgent>().SetDestination(_hit.point);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.CompareTag("Tractor") && other.CompareTag("Field"))
        {
            if (other.GetComponentsInChildren<Transform>().Length <= 1)
            {
                _sfx.PlayOneShot(sowingSeedsSFX);
                Instantiate(youngWheat, other.transform.position, other.transform.rotation, other.transform);
            }
        }
        else if (transform.CompareTag("Harvester") && other.CompareTag("Wheat"))
        {
            _sfx.PlayOneShot(harvestWheatSFX);
            Instantiate(wheatCut, other.transform.position, wheatCut.transform.rotation, other.transform.parent);
            Destroy(other.gameObject);
            gameManager.Instance.increaseScore(1);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FieldZone"))
        {
            if (GetComponent<NavMeshAgent>().velocity.magnitude > 1f)
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FieldZone"))
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
