using UnityEngine;

public class Selector : MonoBehaviour
{
    private bool _isSelected = false;
    private RaycastHit _hit;
    private Station _station;
    private void CreateFlag()
    {
        if (Input.GetMouseButtonDown(0) && _isSelected == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit, 100))
            {
                if (_hit.transform.TryGetComponent<Station>(out _station))
                {
                    _isSelected = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && _isSelected)
        {
            _station.Swith();
            _isSelected = false;
        }
    }

    private void Update()
    {
        CreateFlag();
    }
}
