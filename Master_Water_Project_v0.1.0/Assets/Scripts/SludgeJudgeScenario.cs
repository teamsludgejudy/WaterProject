using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SludgeJudgeScenario : MonoBehaviour
{
    public SludgeType sludgeType;


    public Material[] coloredMats;
    public Color[] sludgeColors;

    [SerializeField] private List<SludgeType> sludgeOptions = new List<SludgeType>();

    public enum SludgeType {Primary, Chemical, ActivatedDark, ActivatedLight};

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            sludgeOptions.Add((SludgeType)i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sludgeOptions.Count > 0 && Input.GetKeyDown(KeyCode.A))
        {
            RandomizeSludge();
            SludgeColor();
        }
    }

    void RandomizeSludge()
    {
        sludgeType = sludgeOptions[Random.Range(0, sludgeOptions.Count)];
        sludgeOptions.Remove(sludgeType);

        Debug.Log("Currently " + sludgeType + " sludge.");
    }

    void SludgeColor()
    {
        for (int i = 0; i < coloredMats.Length; i++)
        {
            coloredMats[i].color = sludgeColors[(int)sludgeType];
        }
    }
}
