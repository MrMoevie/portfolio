using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class PostHighScore : MonoBehaviour
{
	public TMP_InputField InputText;
	public TMP_Text ScoreText;
	private string UserName;
	private int score;

	void Awake() {
		score = GameObject.Find("Highscore").GetComponent<HighscoreScript>().points;

		ScoreText.text = "Score: " + score.ToString();
	}

    public void StartUpload()
    {
    	UserName = InputText.text;
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", UserName);
        form.AddField("score", score.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://146.185.167.8/tapper/addscore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                LoadMenuagain();
            }
            else
            {
                Debug.Log("Form upload complete! " + www.downloadHandler.text);
                LoadMenuagain();
            }
        }
    }
    void LoadMenuagain() {
        GameObject go = GameObject.Find("GameManagement");
        SceneLoader other = (SceneLoader) go.GetComponent(typeof(SceneLoader));
        other.LoadSceneDestroyManagement("menu");
    }
}