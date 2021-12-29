using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using System.Linq;

[Action("Cops/FindClosestCop")]
[Help("Get the Closest Free Cop.")]
public class BBFindClosestCop : BasePrimitiveAction
{
    [OutParam("game object")]
    [Help("Nearest free cop.")]
    public GameObject go;

    public override TaskStatus OnUpdate()
    {
        var l = GameObject.FindGameObjectsWithTag("Cop");
        for(int i = 0; i < l.Count(); i++)
        {
            if(l[i].GetComponent<Moves>().found == false)
            {
                go = l[i];
                Debug.Log(go.name);
                break;
            }
        }

        if (l.Count() == 0)
        {
            return TaskStatus.FAILED;
        }
        else
        {
            var t = GameObject.FindGameObjectsWithTag("Cop").Where(x => x.GetComponent<Moves>().found == true);
            Debug.Log(t.First().name);
            t.First().GetComponent<Moves>().BBSeek(go);
        }

        return TaskStatus.COMPLETED;
    }
}

