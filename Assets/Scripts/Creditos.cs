using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float timeToClose;

    GameObject CreditPanel;
    float timer;
    Vector3 initialPosition;

    private void OnEnable()
    {
        CreditPanel = transform.parent.gameObject;
        initialPosition = transform.position;
    }

    private void OnDisable()
    {
        transform.position = initialPosition;
    }

    void Update()
    {
        if (transform.position.y < CreditPanel.transform.position.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, CreditPanel.transform.position, speed);
        }
        else
        {
            StartCoroutine(CloseCreditPanel(1));
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            StartToClose(timeToClose);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            timer = 0;
        }

        
    }
    void StartToClose (float time)
    {
        timer += Time.deltaTime;
        if(timer>=time)
        {
            CreditPanel.SetActive(false);
            timer = 0;
        }
    }


    IEnumerator CloseCreditPanel (float seconds)
    {
        yield return new WaitForSeconds(seconds);
        CreditPanel.SetActive(false);
            
    }
}
