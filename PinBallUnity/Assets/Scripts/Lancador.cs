using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Transform molaVisual;              // Parte visual da mola
    public Transform pontoDeLancamento;       // Posi��o inicial da mola
    public Rigidbody2D bolaRb;                // Rigidbody da bola
    public float maxPuxada = 1f;              // Dist�ncia m�xima da mola
    public float forcaMaxima = 800f;          // For�a m�xima aplicada na bola

    private float puxadaAtual = 0f;
    private bool puxando = false;

    void Update()
    {
        // Puxando a mola
        if (Input.GetKey(KeyCode.DownArrow))
        {
            puxando = true;
            puxadaAtual += Time.deltaTime;
            puxadaAtual = Mathf.Clamp(puxadaAtual, 0f, maxPuxada);

            // Anima a mola visualmente
            molaVisual.localPosition = pontoDeLancamento.localPosition - new Vector3(0, puxadaAtual, 0);
        }

        // Solta a mola
        if (Input.GetKeyUp(KeyCode.DownArrow) && puxando)
        {
            puxando = false;

            // Calcula for�a proporcional � puxada
            float forcaFinal = (puxadaAtual / maxPuxada) * forcaMaxima;

            // Aplica for�a para cima
            bolaRb.AddForce(Vector2.up * forcaFinal);

            // Reseta mola visualmente
            molaVisual.localPosition = pontoDeLancamento.localPosition;
            puxadaAtual = 0f;
        }
    }
}