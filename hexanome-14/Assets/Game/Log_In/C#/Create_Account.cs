﻿using UnityEngine;
using UnityEngine.SceneManagement;

//This script enables redirection from Sign in Button to Login page in Legends of Andor

public class Create_Account : MonoBehaviour
{
    public void CreateAccount()
    {
        SceneManager.LoadScene("Log_In");

    }
}
