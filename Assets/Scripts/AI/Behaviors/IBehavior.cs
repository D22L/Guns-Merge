using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public interface IBehavior
    {
        float Priority { get; }
        void Behave();
        void Evaluate();
    }
}
