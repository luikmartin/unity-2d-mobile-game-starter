using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class ScenesController : MonoBehaviour
{
    // Animations
    private const string LOAD_VIEW_ANIMATION = "Load";
    private const string LOADED_VIEW_ANIMATION = "Loaded";

    private Animator _animator;

    private string _nextSceneToLoad;


    private void Awake() => _animator = GetComponent<Animator>();

    private void Start()
    {
        Time.timeScale = 1;

        PlayLoadedAnimation();
    }

    public void LoadGameScene()
    {
        _nextSceneToLoad = Constants.GAME_SCENE;
        _animator.Play(LOAD_VIEW_ANIMATION, -1, 0);
    }

    public void LoadMenuScene()
    {
        _nextSceneToLoad = Constants.MENU_SCENE;
        _animator.Play(LOAD_VIEW_ANIMATION, -1, 0);
    }

    public void PlayLoadedAnimation() => _animator.Play(LOADED_VIEW_ANIMATION, -1, 0);

    public void AnimatorHandleNextSceneLoad() => StartCoroutine(LoadScene(_nextSceneToLoad));

    private IEnumerator LoadScene(string sceneName)
    {
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
