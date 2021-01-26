using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

		private Animator anim;
		float movx, movz; // Variabili per memorizzare l'input del controller 
		Rigidbody rb;
		public float speed; // Setto la velocità di movimento 
		 // Variabile che permette il movimento del mio personaggio negli assi 
		[SerializeField] float maxspeed;
		[SerializeField] float vel;
		public Vector3 mass;
		//public Text DEAD;
		public GameObject Respawn;
		public bool Morto;

	void Start () 
	{
		anim = gameObject.GetComponentInChildren<Animator>();// abbiamo messo l'animator dove possiamo accedere agli stati per richiamarli quando ci servono
		rb = GetComponent<Rigidbody>(); //recupero il componente del rigidbody del mio player  perchè le informazioni siano accessibili
	}

	void Update()
	{

		if (!Morto)
		{

			if (movz != 0)
			{
				anim.SetBool("isidle", true);
			} // quando è maggiore di 0 corre se è 0 o è meno va in iddle 
			else
			{
				anim.SetBool("isidle", false);
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			 movx = Input.GetAxis("Horizontal");//diamo l'input al comando 
			 movz = Input.GetAxis("Vertical");//muovere il personaggio in avanti 

			Vector3 movimento = new Vector3(0, movx, 0); //
			transform.Rotate(movimento); //ruotasuitre assi,creo assi nuovi non ruoto solo nell'asse y cosi si gira nel momento in cui arriva l'input del movx e movz
										 // incremento assi va da 0.0f a 1.0f
										 //  spinta =z*movimento*velocità 
										 // spinta=z*0*velocità =fermo 
										 // spinta =Z*(1*velocità)= avanti
										 // spinta=z*(-1*velocità)= indietro
			movimento.y = rb.velocity.y;
			mass = movimento * rb.mass;
			rb.AddForce(transform.forward * (movz * speed) * Time.deltaTime, ForceMode.Acceleration); //movimento in avanti forward,incremento l'asse per andare avanti moltiplicando la velocità spingendo in avanti, delta time e do accelerazione con  la forza 
																									  //vel = rb.velocity.magnitude;                                                           //prendo nella fisica velocity e magnitudo,il valore recupera l'accelerazione fa vedere a quanti kilometri orari sta andando
			print(vel);
			//rb.velocity = new Vector3(rb.velocity.x, mass.y, rb.velocity.z); //determina la massa dell'oggetto 


			if (vel >= maxspeed) //se la velocità sara maggiore del max speed terrò la velocità costante
			{
				rb.velocity = rb.velocity.normalized * maxspeed;
			}

		}
	}

		private void FixedUpdate()
		{

		//movement = new Vector3(movx, 0, movz);  // Assegno a movement le informazioni del ciclo della fisica

		//rb.AddForce(movement * speed);

		}
	private void OnCollisionEnter(Collision collision)//con la variabile collision rileva dove va il nostro oggetto va a sbattere. Inoltre collision enter può essere scritto sono una volta 
	{
		// print(collision.gameObject.tag);
		if (collision.gameObject.tag == " Mostro") //se il nostro cubo va a spattere contro questo oggetto
		{

			print(" DEAD ");// nel caso va a sbattere deve stampare questo
			speed = 0;
			//DEAD.text = "DEAD";
			transform.position = Respawn.transform.position;
			//Destroy(collision.gameObject);//distrugge l'oggetto contro cui va a sbattere 
			//print("DEAD");// stamperà ostacolo
			anim.SetBool("DIE", true); //Se tocco il nemico muoio
			Morto = true; 
		}
	}
}


