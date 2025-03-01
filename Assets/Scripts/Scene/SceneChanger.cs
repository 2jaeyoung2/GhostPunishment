using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private Button start;

    public Image fadeImage;

    private Color imageColor;

    public float fadeDuration = 1f;

    private void OnEnable()
    {
        imageColor.a = 0;

        fadeImage.color = imageColor;

        fadeImage.gameObject.SetActive(false);

        start.onClick.AddListener(() => StartCoroutine(ChangeScene("BattleScene")));
    }

    private IEnumerator ChangeScene(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            Color fadeColor = fadeImage.color;

            fadeColor.a = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);

            fadeImage.color = fadeColor;

            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }

    private void OnDisable()
    {
        start.onClick.RemoveListener(() => ChangeScene("BattleScene"));
    }
}
