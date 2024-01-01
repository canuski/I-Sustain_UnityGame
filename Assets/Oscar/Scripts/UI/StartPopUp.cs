using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPopUp : MonoBehaviour
{
    [SerializeField] GameObject FirstTask;
    
    public void LetsGo()
    {
        FirstTask.SetActive(false);
    }

}
