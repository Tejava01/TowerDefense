using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScene : Singleton<ManagerScene>
{
    [SerializeField] private Canvas UIFrameLoading;
    [SerializeField] private Slider ProgressBar;

    [Tooltip("로딩 시간이 짧아 순간적으로 로딩창을 넘기는 것을 방지하기 위한 최소 로딩 시간입니다.")]
    [SerializeField] private float MinLoadingTime = 2f;

    //-----------------------------------------------------------------

    public void DoLoadTitleScene(Action delFinish)
    {
        PrivLoadScene("SceneTitle", true, true, delFinish);
    }

    public void DoLoadStageScene(Action delFinish)
    {
        PrivLoadScene("SceneStage", true, true, delFinish);
    }

    public void DoLoadBattleScene(int stageNumber, Action delFinish)
    {
        ManagerSave.Instance.SetCurrentStage(stageNumber);
        PrivLoadScene("SceneBattle", true, true, delFinish);
    }

    public void DoExitGame()
    {
        PrivExitGame();
    }

    //-----------------------------------------------------------------

    private IEnumerator CoroutineLoadScene(string sceneName, bool setAsMain, bool unloadCurrent, Action delFinish)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        UIFrameLoading.gameObject.SetActive(true);

        while (!asyncLoad.isDone)
        {
            float currentProgress = asyncLoad.progress;

            ProgressBar.value = currentProgress;

            yield return null;
        }

        if (sceneName == "SceneBattle") BattleSimulateManual.Instance.DoGamePause();

        //원래는 A씬 로딩씬 B씬 비동기로 전환해야함 (메모리피크방지)
        if (unloadCurrent == true)
        {
            string activeScene = SceneManager.GetActiveScene().name;
            SceneManager.UnloadSceneAsync(activeScene);
        }

        if (setAsMain == true)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            delFinish?.Invoke();
        }
        
        yield return new WaitForSeconds(MinLoadingTime);
        UIFrameLoading.gameObject.SetActive(false);
        if (sceneName == "SceneBattle") BattleSimulateManual.Instance.DoGameResume();
    }

    private void PrivLoadScene(string sceneName, bool setAsMain, bool unloadCurrent, Action delFinish)
    {
        StartCoroutine(CoroutineLoadScene(sceneName, setAsMain, unloadCurrent, delFinish));
    }

    private void PrivExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
