using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    // ��� ����� �� ���������, ��� �� ���� �������� ������� ������ � ���� �����, � ����� ��� ������� ����� ��������� � ������� �� ��� ���������, ��� ����� ������.
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private LoadingScene _loadingScene;
    [SerializeField] private Button[] _levelButtons;

    public void UpdateLevels(List<LevelData> levelDatas)
    {
        for(int i = 0; i < _levelButtons.Length; i++)
        {
            Debug.Log(levelDatas[i].IsUnblock);
            _levelButtons[i].GetComponent<LevelButton>().UnblockButton(levelDatas[i].IsUnblock);
            _levelButtons[i].interactable = levelDatas[i].IsUnblock;
            _levelButtons[i].GetComponent<LevelButton>().UpdateStars(levelDatas[i].Stars);
        }
    }

    public void Select(string levelName)
    {
        //_sceneFader.FadeTo(levelName);
        _loadingScene.LoadScene(levelName);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
