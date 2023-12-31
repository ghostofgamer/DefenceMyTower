using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransitions : Transitions
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;

    public bool Flag { get; set; }

    private void Start()
    {
        _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < _transitionRange)
        {
            NeedTransit = true;
        }
    }
}
