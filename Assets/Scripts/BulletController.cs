﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletController : MonoBehaviour {
	
	public static BulletController current;
	public GameObject pooledObject;
	public int pooledAmount = 20;
	public bool willGrow = false;
	
	List<GameObject> pooledObjects;
	
	// Use this for initialization
	
	void Awake()
	{
		current = this;
	}
	
	void Start () {
		
		pooledObjects = new List<GameObject>();
		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if(!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}
		
		if(willGrow)
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			pooledObjects.Add(obj);
			return obj;
		}
		
		return null;
	}
}
