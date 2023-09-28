using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity = 16;

    protected List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
    protected bool TryGetObject(out WarriorChanger result)
    {
        result = null;
        foreach (var item in _pool)
        {
            if (item.TryGetComponent(out WarriorChanger warrior))
            {
                if (warrior.IsWarriorActive == false)
                {
                    result = warrior;
                    break;
                }
            }
        }
        //result = _pool.FirstOrDefault(p => p.GetComponent<WarriorChanger>().IsWarriorActive == false).GetComponent<WarriorChanger>();

        return result != null;
    }
}
