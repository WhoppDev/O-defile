using UnityEngine;

public class LuzesTrio : MonoBehaviour
{
    public float velocidadeRotacao = 1f;
    public float amplitude = 30f;
    public float velocidadeCor = 1f;

    private float anguloBase;
    private Light luz;

    void Start()
    {
        anguloBase = transform.eulerAngles.x;
        luz = GetComponentInChildren<Light>();
    }

    void Update()
    {
        float deslocamento = Mathf.Sin(Time.time * velocidadeRotacao) * (amplitude / 2f);
        transform.eulerAngles = new Vector3(anguloBase + deslocamento, transform.eulerAngles.y, transform.eulerAngles.z);

        float hue = Mathf.Repeat(Time.time * velocidadeCor, 1f);
        luz.color = Color.HSVToRGB(hue, 1f, 1f);
    }
}
