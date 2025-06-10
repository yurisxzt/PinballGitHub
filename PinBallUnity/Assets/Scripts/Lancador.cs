using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Transform molaVisual;              
    public Transform pontoDeLancamento;      
    public Rigidbody2D bolaRb;                
    public float maxPuxada = 1f;             
    public float forcaMaxima = 800f;         

    private float puxadaAtual = 0f;
    private bool puxando = false;

    void Update()
    {
       
        if (Input.GetKey(KeyCode.DownArrow))
        {
            puxando = true;
            puxadaAtual += Time.deltaTime;
            puxadaAtual = Mathf.Clamp(puxadaAtual, 0f, maxPuxada);


            molaVisual.localPosition = pontoDeLancamento.localPosition - new Vector3(0, puxadaAtual, 0);
        }

        
        if (Input.GetKeyUp(KeyCode.DownArrow) && puxando)
        {
            puxando = false;

            
            float forcaFinal = (puxadaAtual / maxPuxada) * forcaMaxima;

           
            bolaRb.AddForce(Vector2.up * forcaFinal);

           
            molaVisual.localPosition = pontoDeLancamento.localPosition;
            puxadaAtual = 0f;
        }
    }
}