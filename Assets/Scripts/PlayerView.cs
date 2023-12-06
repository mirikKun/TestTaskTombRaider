using UnityEngine;

public class PlayerView:MonoBehaviour
{
    [SerializeField] private GameObject _view;
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _shieldedMaterial;

    public void ChangeMaterialToShielded()
    {
        _mesh.material = _shieldedMaterial;
    }
    public void ChangeMaterialToDefault()
    {
        _mesh.material = _defaultMaterial;
    }
    public void HidePlayer()
    {
        _view.SetActive(false);
    }

    public void ShowPlayer()
    {
        _view.SetActive(true);
    }
}