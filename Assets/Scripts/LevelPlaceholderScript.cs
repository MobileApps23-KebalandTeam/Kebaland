
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPlaceholderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelPassed()
    {
        PushInfoToParent(true);
    }

    public void LevelFailed()
    {
        PushInfoToParent(false);
    }

    private static void PushInfoToParent(bool nextLevel)
    {
        LevelChoice.UpdateLevel(nextLevel, LevelType.KEBAB);
        SceneManager.LoadScene("LevelsChoiceScene");
    }
}
