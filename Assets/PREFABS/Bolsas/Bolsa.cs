using UnityEngine;

public class Bolsa : MonoBehaviour
{
	public Pallet.Valores Monto;
	//public int IdPlayer = 0;
	public string TagPlayer = "";
	public Texture2D ImagenInventario;
	Player Pj = null;
	
	bool Desapareciendo;
	public GameObject ParticulasPref;
	public float TiempParts = 2.5f;


	Renderer renderBolsa;
	Collider collBolsa;
	ParticleSystem parSystem;

	void Start () 
	{
		Monto = Pallet.Valores.Valor2;
		

		renderBolsa = GetComponent<Renderer>();
		collBolsa = GetComponent<Collider>();
	}
	
	void Update ()
	{
		
		if(Desapareciendo)
		{
			TiempParts -= Time.deltaTime;
			if(TiempParts <= 0)
			{
				renderBolsa.enabled = true;
				collBolsa.enabled = true;

				gameObject.SetActive(false);
			}
		}
		
	}
	
	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == TagPlayer)
		{
			Debug.Log("BOLSA");

			Pj = coll.GetComponent<Player>();
			if(Pj.AgregarBolsa(this))
            {
				Instantiate(ParticulasPref, transform.position + (Vector3.up * 2), Quaternion.identity);
				Desaparecer();
            }
		}
	}
	
	public void Desaparecer()
	{
		Desapareciendo = true;
		
		renderBolsa.enabled = false;
		collBolsa.enabled = false;
	}
}
