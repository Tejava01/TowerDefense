using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerAttacher : MonoBehaviour
{
    private void Awake()
    {
        BootingUp();
    }
    
    //----------------------------------------------

    private void BootingUp()
    {
        if (SceneManager.GetSceneByName("SceneAttacher").isLoaded == false)
        {
            Debug.Log("�Ŵ��� ���ÿϷ�");
            SceneManager.LoadScene("SceneAttacher", LoadSceneMode.Additive);
        }
    }
}
