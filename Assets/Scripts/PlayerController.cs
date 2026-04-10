using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; //variable para guardar la velocidad
    public int score = 0;
    public bool hasKey = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //leer las teclas WASD o las flechas
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    //Este método especial de unity se ejecuta cuando interactuamos con un objeto en modo trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Key"))
         {
            hasKey = true;
            Destroy(other.gameObject);
            Debug.Log("Tienes la llave!");
         }

        if(other.CompareTag("Collectable"))
        {
            score = score + 1; //Le sumo 1 a la variable score
            Destroy(other.gameObject);
            Debug.Log("Collected!");
            Debug.Log("Score: " + score);

            //Condición para ganar el juego
            if(score >= 3 && hasKey == true)
            {
                Debug.Log("Ganaste!!");
            }
            else
            {
                Debug.Log("¡Sigue intentando! Necesitas 3 en total para ganar");
            }
        }

         
    }

}