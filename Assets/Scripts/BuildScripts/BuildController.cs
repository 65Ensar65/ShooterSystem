using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : Base,IBuildable
{
    public void GetBuildControl()
    {
        Destroy(GetComponent<ObiCollider>());
        e_rigidbody.isKinematic = false;
    }
}
