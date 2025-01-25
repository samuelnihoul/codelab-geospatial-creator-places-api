using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZombieMover : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    public int hp = 5;
    [SerializeField]
    private float altitudeCameraOffset = -2f;
    [SerializeField]
    private float lifeInSeconds = 60;
    [SerializeField]
    private Image hitIndicator;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (Camera.main.transform.position - transform.position).normalized;
        direction.y = 0; // Set y component to zero to move only horizontally
        transform.Translate(direction * speed * Time.deltaTime, Space.World); // Use World space to move horizontally
        transform.rotation = Quaternion.LookRotation(direction);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        Vector3 a = transform.position;
        a.y = Camera.main.transform.position.y + altitudeCameraOffset;
        transform.position = a;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("ball"))
        {
            Flash();
            hp--;
            Destroy(collision.gameObject);
        }
        if (collision.transform.CompareTag("MainCamera"))
        {
            
            // doesn't work currently
            GameObject.FindGameObjectWithTag("hintText").GetComponent<TextMeshProUGUI>().text = "you got bitten by zombies";
        }
    }
    private IEnumerator Flash()
    {
        for (int i = 0; i < 2; i++)
        {
            // Changer la couleur en rouge
            hitIndicator.color = Color.red;
            yield return new WaitForSeconds(1);

            // Revenir à la couleur d'origine
            hitIndicator.color = Color.white;
            yield return new WaitForSeconds(1);
        }
    }

}
