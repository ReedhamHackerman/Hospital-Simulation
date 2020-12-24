using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour
{
    [Tooltip("Patient Prefab Here")][SerializeField]public GameObject patient;
    public  int numberOfPatient;
    // Start is called before the first frame update
    void Start()
    {
        
        TimeManager.Instance.Initialize();
        TimeManager.Instance.AddDelegate(() => { SpawnPatient(); }, 3.4f, numberOfPatient);
    }
    void SpawnPatient()
    {
        Instantiate(patient, this.transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        TimeManager.Instance.Refresh();
    }
}
