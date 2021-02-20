using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void OnTriggerEnter2D(Collider2D other)
	{
		AstroController controller = other.GetComponent<AstroController>();
		if (controller != null)
		{
			controller.ChangeScore();
            controller.Pick();
			Destroy(base.gameObject);
		}
	}
}