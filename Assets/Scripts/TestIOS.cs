using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIOS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_IOS
        Debug.Log("Iphone");
#endif
#if UNITY_STANDALONE || UNITY_FACEBOOK || UNITY_WEBGL
        Debug.Log("PC or WebL");
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
