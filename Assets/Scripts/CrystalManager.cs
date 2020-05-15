using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    public List<GameObject> crystalPrefabs = new List<GameObject>();
    public List<GameObject> crystalAnchors = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        var anchorQueue = new Queue<GameObject>(crystalAnchors);
        var crystalQueue = new Queue<GameObject>(crystalPrefabs);

        for (var i = 0; i < GameSettings.CRYSTALS; i++)
        {
            var c = Instantiate(crystalQueue.Dequeue());
            c.transform.SetParent(anchorQueue.Dequeue().transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
