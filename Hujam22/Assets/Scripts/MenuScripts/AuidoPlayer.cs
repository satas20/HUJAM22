using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuidoPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private static AuidoPlayer instance;

    // Read-only public access
    public static AuidoPlayer Instance => instance;

    private void Awake()
    {
        // Does another instance already exist?
        if (instance && instance != this)
        {
            // Destroy myself
            Destroy(gameObject);
            return;
        }

        // Otherwise store my reference and make me DontDestroyOnLoad
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
