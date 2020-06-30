using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameEnded;
    public void GameOver()
	{
        if(gameEnded == true)
		{
            return;
		}

        gameEnded = true;

        StartCoroutine(beginGameOver());
	}

    IEnumerator beginGameOver()
	{
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
