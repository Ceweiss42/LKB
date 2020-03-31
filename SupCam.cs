using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Camera))]
public class SupCam : MonoBehaviour
{

	public List<Transform> Players;
	public Vector3 offset;
	public Transform playerOne, playerTwo;
	private Vector3 Velocity;
	public float SmoothTime;

	public float minZoom;
	public float maxZoom;
	public float Division;
	private Camera cam;

    void Start()
	{
		Players = new List<Transform>();
		cam = GetComponent<Camera>();

		Players.Add(playerOne);
		Players.Add(playerTwo);
	}

    void LateUpdate()
	{
        if(Players.Count == 0)
		{
			return;
		}
		Move();
		Zoom();
	}

    void Zoom()
	{
		float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / Division);
		cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
	}

    float GetGreatestDistance()
	{
		var bounds = new Bounds(Players[0].position, Vector3.zero);
        for(int i = 0; i < Players.Count; i++)
		{
			bounds.Encapsulate(Players[i].position);
			
		}
		return bounds.size.z;


	}

    void Move()
	{
		Vector3 centerPoint = GetCenterPoint();

		Vector3 newPosition = centerPoint + offset;

		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref Velocity, SmoothTime);
	}

    Vector3 GetCenterPoint()
	{
        if(Players.Count == 1)
		{
			return Players[0].position;
		}

		var bounds = new Bounds(Players[0].position, Vector3.zero);
        for(int i = 0; i < Players.Count; i++)
		{
			bounds.Encapsulate(Players[i].position);
		}

		return bounds.center;
	}
}
