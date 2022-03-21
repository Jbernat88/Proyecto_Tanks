using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoindoInBetween : MonoBehaviour
{
    private SoindoInBetween instance;
    private SoindoInBetween Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)//Cuando cambiamos de escena nustro objeto no se duplica
        {
            Destroy(gameObject);
        }

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);//No se destruye nuestro obejto mientras se esta ejecutando la accion
    }


}
