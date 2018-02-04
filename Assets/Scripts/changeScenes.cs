using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

class changeScenes : MonoBehaviour {

	public int delay = 0;
		
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Cinta")
		{
			StartCoroutine("LoadAfterDelay");			
		}
	}

	public void NextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Reset()
    {
        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LoadAfterDelay()
	{
		yield return new WaitForSeconds(delay);
        NextLevel();
	}


}
