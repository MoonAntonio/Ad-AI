//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EnemigoIA.cs (30/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Control de la IA del enemigo								\\
// Fecha Mod:		30/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Control de la IA del enemigo</para>
	/// </summary>
	public class EnemigoIA : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Objetivo del enemigo.</para>
		/// </summary>
		public Transform target;									// Objetivo del enemigo
		#endregion

		#region Actualizador
		/// <summary>
		/// <para>Actualizador de EnemigoIA.</para>
		/// </summary>
		private void Update()// Actualizador de EnemigoIA
		{
			// Si hay objetivo
			if (target)
			{
				// Direccion
				Vector3 dir = target.position - this.transform.position;
				if (dir == Vector3.zero)
				{
					dir = transform.forward;
				}

				// Rotacion
				Quaternion rot = Quaternion.LookRotation(dir);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rot, Time.deltaTime * 5f);
			}
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando colisiona con un collider.</para>
		/// </summary>
		/// <param name="other">El collider con el que choca.</param>
		private void OnTriggerEnter(Collider other)// Cuando colisiona con un collider
		{
			// Asignamos como objetivo el objeto colisionado
			target = other.transform;
		}
		#endregion

	}
}
