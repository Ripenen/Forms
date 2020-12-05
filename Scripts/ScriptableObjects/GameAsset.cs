using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GameAsset : ScriptableObject
{
    public GameObject Form;
    public GameObject Barricade;

    private GameObject _form;
    private GameObject _barricade;

    public void Spawn()
    {
        float _randomAngle = Random.Range(-360f, 360f);

        _form = Instantiate(Form, Vector3.zero, Quaternion.Euler(0, 0, _randomAngle));

        _randomAngle = Random.Range(-360f, 360f);

        _barricade = Instantiate(Barricade, new Vector3(0, 0, 10), Quaternion.Euler(0, 0, _randomAngle));
    }

    public BarricadeControl GetBarricadeControl()
    {
        return _barricade.GetComponent<BarricadeControl>();
    }

    public void Despawn()
    {
        Destroy(_form);
        Destroy(_barricade);
    }
}
