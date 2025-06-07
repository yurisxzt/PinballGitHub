using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Transform molaVisual;              // Parte visual da mola
    public Transform pontoDeLancamento;       // Posição inicial da mola
    public Rigidbody2D bolaRb;                // Rigidbody da bola
    public float maxPuxada = 1f;              // Distância máxima da mola
    public float forcaMaxima = 800f;          // Força máxima aplicada na bola

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

            // Calcula força proporcional à puxada
            float forcaFinal = (puxadaAtual / maxPuxada) * forcaMaxima;

            // Aplica força para cima
            bolaRb.AddForce(Vector2.up * forcaFinal);

            // Reseta mola visualmente
            molaVisual.localPosition = pontoDeLancamento.localPosition;
            puxadaAtual = 0f;
        }
    }
}