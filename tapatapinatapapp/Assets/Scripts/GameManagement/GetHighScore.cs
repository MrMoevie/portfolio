using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;

public class GetHighScore : MonoBehaviour
{
	public TextMeshProUGUI TextPro;
	private string highscores;
	private int pagenumber = 0;

	void Start()
	{
		StartCoroutine(GetRequest());
	}

	public void NextPage() {
		pagenumber += 5;
		Start();
	}

	public void PreviousPage() {
		if(pagenumber == 0) {
			GameObject go = GameObject.Find("HighscoreManagement");
			SceneLoader other = (SceneLoader) go.GetComponent(typeof(SceneLoader));
			other.LoadSceneDestroyManagement("menu");
		} else {
			pagenumber -= 5;
			Start();
		}
	}

	IEnumerator GetRequest()
	{
		WWWForm form = new WWWForm();
		form.AddField("page", pagenumber);
		var uri = "http://146.185.167.8/tapper/display.php";
		using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
		{
            // Request and wait for the desired page.
			yield return www.SendWebRequest();

			string[] pages = uri.Split('/');
			int page = pages.Length - 1;

			if (www.isNetworkError)
			{
				Debug.Log(pages[page] + ": Error: " + www.error);
			}
			else
			{
				highscores = www.downloadHandler.text;
				TextPro.text = highscores;
			}
		}
	}
}