using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start () {
        Invoke("LoadNextLevel", 3f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
