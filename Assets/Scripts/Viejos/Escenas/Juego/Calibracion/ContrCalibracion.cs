using UnityEngine;

public class ContrCalibracion : MonoBehaviour
{
	public Player Pj;
	/*
	public string ManoIzqName = "Left Hand";
	public string ManoDerName = "Right Hand";
	
	bool StayIzq = false;
	bool StayDer = false;
	*/
	/*
	public float TiempCalib = 3;
	float Tempo = 0;
	*/
	public float TiempEspCalib = 3;
	float Tempo2 = 0;
	
	//bool EnTutorial = false;
	
	public enum Estados{Calibrando, Tutorial, Finalizado}
	public Estados EstAct = Estados.Calibrando;
	
	public ManejoPallets Partida;
	public ManejoPallets Llegada;
	public Pallet P;
    public ManejoPallets palletsMover;
	
	GameManager GM;
	
	//----------------------------------------------------//
	
	// Use this for initialization
	void Start () 
	{
        /*
		renderer.enabled = false;
		collider.enabled = false;
		*/
        palletsMover.enabled = false;
        Pj.ContrCalib = this;
		
		GM = GameObject.Find("GameMgr").GetComponent<GameManager>();
		
		P.CintaReceptora = Llegada.gameObject;
		Partida.Recibir(P);
		
		SetActivComp(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(EstAct == ContrCalibracion.Estados.Tutorial)
		{
			if(Tempo2 < TiempEspCalib)
			{
				Tempo2 += T.GetDT();
				if(Tempo2 > TiempEspCalib)
				{
					 SetActivComp(true);
				}
			}
		}
	}
	
	void FinCalibracion()
	{
		/*
		Reiniciar();
		GM.CambiarATutorial(Pj.IdPlayer);
		*/
	}
	
	public void IniciarTesteo()
	{
		EstAct = ContrCalibracion.Estados.Tutorial;
        palletsMover.enabled = true;
        //Reiniciar();
    }
	
	public void FinTutorial()
	{
		EstAct = ContrCalibracion.Estados.Finalizado;
        palletsMover.enabled = false;
        GM.FinCalibracion(Pj.IdPlayer);
	}
	
	void SetActivComp(bool estado)
	{
		if(Partida.GetComponent<Renderer>() != null)
			Partida.GetComponent<Renderer>().enabled = estado;
		Partida.GetComponent<Collider>().enabled = estado;
		if(Llegada.GetComponent<Renderer>() != null)
			Llegada.GetComponent<Renderer>().enabled = estado;
		Llegada.GetComponent<Collider>().enabled = estado;
		P.GetComponent<Renderer>().enabled = estado;
	}
}
