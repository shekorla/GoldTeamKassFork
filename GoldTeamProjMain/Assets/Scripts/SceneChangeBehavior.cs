using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeBehavior : MonoBehaviour
{
    //public IntData sceneNum;

    public void ChangeScene(string sceneName)//use when changing scenes
    {
        SceneManager.LoadScene(sceneName);
    }

    public void tempLeaveOverworld(string sceneName)//use when changing scenes for combat
    {
        GameObject.Find("base room").BroadcastMessage("leaveRoom");
        ChangeScene(sceneName);
    }
    //this is all the old code from JM keeping it here for ref, probs need to scrap it at some point
    
    //yeah, this was pretty bad code. thank you for making a much simpler (and smarter) function!  -JM
    /*public void GameStart()
    {
        SceneManager.LoadScene("Scenes/LevelScene"+sceneNum.value );
    }

    public void GameLevelComplete()
    {
        SceneManager.LoadScene("Scenes/LevelTransitionScene");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("Scenes/GameOverScene");
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Scenes/TitleScene");
    }
    public void End()
    {
        SceneManager.LoadScene("Scenes/EndScene");
    }*/
    
    
}
