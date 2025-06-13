using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    static float a = 4f;                
    static float b = 2f; // float h = 6.0f  int h = 6
    float c = a / b;
    static string s1 = "first string";
    static string s2 = "second string";
    string third_string = s1 + s2; //s2 s_2 ads
    void Start()
    {
        float d = 0.25f;
        double e = 0.25;
        Debug.Log($"Значение переменной third_string = {third_string}");
    }

    void Update()
    {
        
    }
}
