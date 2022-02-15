using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeRunner : MonoBehaviour
{
    BehaviourTree tree;

    // Start is called before the first frame update
    void Start()
    {
        tree = ScriptableObject.CreateInstance<BehaviourTree>();
        var log1 = ScriptableObject.CreateInstance<DebugLogNode>();
        var log2 = ScriptableObject.CreateInstance<DebugLogNode>();
        var log3 = ScriptableObject.CreateInstance<DebugLogNode>();

        log1.message = "First Loggg 1";
        log2.message = "First Loggg 2";
        log3.message = "First Loggg 3";

        var WaitNode1 = ScriptableObject.CreateInstance<WaitNode>();
        var WaitNode2 = ScriptableObject.CreateInstance<WaitNode>();
        var WaitNode3 = ScriptableObject.CreateInstance<WaitNode>();

        var sequence = ScriptableObject.CreateInstance<SequencerNode>();
        sequence.children.Add(log1);
        sequence.children.Add(WaitNode1);
        sequence.children.Add(log2);
        sequence.children.Add(WaitNode2);
        sequence.children.Add(log3);
        sequence.children.Add(WaitNode3);


        var loop = ScriptableObject.CreateInstance<RepeatNode>();
        loop.child = sequence;

        tree.rootNode = loop;
    }

    // Update is called once per frame
    void Update()
    {
        tree.Update();
    }
}
