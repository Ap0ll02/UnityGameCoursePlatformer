using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] float playerLives = 3f;
    void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if(numGameSession > 1){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
        
    }
    public IEnumerator ProcessPlayerDeath(){
        yield return new WaitForSecondsRealtime(1);
            if(playerLives > 1){
                TakeLife();
            }else{ ResetGameSession(); }
        }

    void ResetGameSession(){
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    void TakeLife(){
        playerLives --;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
