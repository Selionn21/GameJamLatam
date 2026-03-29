using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform objetivo;
    public float velocidadCam = 0.025f;
    public Vector3 desplazamiento;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 posicionDeseada = objetivo.position + desplazamiento;

        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, velocidadCam);

        transform.position = posicionSuavizada;
    }
}
