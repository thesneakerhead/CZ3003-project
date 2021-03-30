using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacter : MonoBehaviour
{
    public string selection;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
  
}
