using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlaceTower : MonoBehaviour
{
    [SerializeField] private GameObject _firstPanelUI;
    [SerializeField] private UpgradePanel _upgradePanelUI;
    [SerializeField] private Tower[] _towers;
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _flag;

    private GameObject _currentPanel;
    private ObjectManagerUI _objectManager;
    private SpawnPlaceTowerBeaty _spawnPlaceTowerBeaty;
    private float _radius = 5f;

    private void Start()
    {
        _currentPanel = _firstPanelUI;
        _spawnPlaceTowerBeaty = GetComponent<SpawnPlaceTowerBeaty>();
    }

    public void Init(ObjectManagerUI objectManagerUI)
    {
        _objectManager = objectManagerUI;
    }

    public void PlaceTower(int index)
    {
        _spawnPlaceTowerBeaty.CloseBlankTower();
        _spawnPlaceTowerBeaty.PlayParticles();
        _towers[index].gameObject.Activate();
        _currentPanel.Deactivate();
        _flag.Deactivate();
        _upgradePanelUI.TowerChoice(ref _towers[index]);
        _currentPanel = _upgradePanelUI.gameObject;
    }

    public void ShowBlankTower(int index)
    {
        _spawnPlaceTowerBeaty.ShowBlankTower(index, _towers[index].Radius);
        _radius = _towers[index].Radius;
    }

    public void CloseBlankTower(int index)
    {
        _spawnPlaceTowerBeaty.CloseBlankTower(index);
    }

    public void OpenPanel()
    {
        _objectManager.CloseUI();
        _currentPanel.Activate();
        _objectManager._event?.Invoke(true);
    }

    public void ClosePanel()
    {
        _objectManager._event?.Invoke(false);
        _spawnPlaceTowerBeaty.CloseBlankTower();
        _upgradePanelUI.CloseRangeField();
        _currentPanel.Deactivate();
    }

    public Tower GetTower(int index)
    {
        return _towers[index];
    }

    public void ResetSettings()
    {
        _currentPanel.SetActive(false);
        _currentPanel = _firstPanelUI;
        _flag.Activate();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position, _radius);
    }
}
