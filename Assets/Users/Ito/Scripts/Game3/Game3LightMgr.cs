﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game3LightMgr : MonoBehaviour {

    Material m_material;        // マテリアル

    float m_offsetValue = 1.0f / 6.0f;

    public Transform m_effectParent;  // エフェクトの親オブジェクト
    ParticleSystem[] m_particle;

    public enum eColor { RED, YELLOW, GREEN, BLUE, PURPLE, WHITE };
	// Use this for initialization
	void Start () {
        m_material = this.renderer.material;
        m_particle = m_effectParent.GetComponentsInChildren<ParticleSystem>();
        ChangeColor(eColor.WHITE);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeColor(string color)
    {
        switch (color)
        {
            case "Red": ChangeColor(eColor.RED); break;
            case "Yellow": ChangeColor(eColor.YELLOW); break;
            case "Blue": ChangeColor(eColor.BLUE); break;
            case "Green": ChangeColor(eColor.GREEN); break;
        }
    }

    void ChangeColor(eColor color){
        // ライトのオブジェクトの色変更
        m_material.mainTextureOffset = new Vector2((m_offsetValue * (int)color),0.0f);

        Color col = Color.white;
        switch(color){
            case eColor.RED: col = Color.red; col.a = 128; break;
            case eColor.YELLOW: col = Color.yellow; col.a = 128; break;
            case eColor.GREEN: col = Color.green; col.a = 128; break;
            case eColor.BLUE: col = Color.blue; col.a = 128; break;
            case eColor.PURPLE: col = new Color(200,0,255,128); break;
            case eColor.WHITE: col = Color.white; col.a = 128; break;
        }

        // パーティクルの色変更
        foreach (ParticleSystem ps in m_particle)
        {
            ps.startColor = col;
            ps.renderer.material.color = col;
        }
    }
}
