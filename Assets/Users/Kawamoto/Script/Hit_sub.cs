﻿using UnityEngine;
using System.Collections;

public class Hit_sub : MonoBehaviour {

	//入力
	InputMg	   input_bt;
	GameObject go;
	
	// コンポーネント用
	GameMain 		gamemain;
	GameMain_sub 	gamemain_sub;
	Hit				hit;
	CharSpeedMgr	charspeed_mgr;
	Score			score;

	// ヒットしている色
	int HitNum = 0;
	
	// Use this for initialization
	void Start () {
		
		// コンポーネントをゲット
		gamemain = GameObject.Find ("Pare").GetComponent<GameMain> ();
		gamemain_sub = GameObject.Find ("Pare").GetComponent<GameMain_sub> ();
		hit = GameObject.Find ("Spot_L").GetComponent<Hit> ();
		input_bt = GameObject.Find ("InputMane").GetComponent<InputMg> ();
		charspeed_mgr = GameObject.Find ("Speed_Mgr").GetComponent<CharSpeedMgr> ();
		score = GameObject.Find ("Score_name").GetComponent<Score> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		// 当たっていないときにボタンを押すと飛ぶ
		if (input_bt.AnyTrigger()) {
			if (gamemain_sub.ObjFlagC () == 0 && gamemain.ObjFlagC () == 0 && 
			    GameObject.Find ("SayonaraLine").transform.position.x < this.transform.position.x) {
				gamemain_sub.SayonaraObj();
				//charspeed_mgr.SpeedDown();
			}
		}
	}

	private void OnTriggerEnter(Collider other){
		HitNum = 0;
		// フラグを立てる
		gamemain_sub.ObjHitOn ();

		if (other.gameObject.renderer.material.name == "Red (Instance)" || 
		    other.gameObject.renderer.material.name == "red") {
			HitNum = 1;
		}
		
		if (other.gameObject.renderer.material.name == "Green (Instance)" ||
		    other.gameObject.renderer.material.name == "green") {
			HitNum = 2;
		}
		
		if (other.gameObject.renderer.material.name == "Blue (Instance)" ||
		    other.gameObject.renderer.material.name == "blue") {
			HitNum = 3;
		}
		
		if (other.gameObject.renderer.material.name == "Yerrow (Instance)" ||
		    other.gameObject.renderer.material.name == "yerrow") {
			HitNum = 4;
		}
	}
	
	// ボタンを押したときの処理
	private void OnTriggerStay(Collider other)
	{
		//Debug.Log(other.gameObject.renderer.material.name);
		if (input_bt.RedTrigger ()) { 
			if (HitNum == 1) {					
				charspeed_mgr.CountUp ();		// 難易度設定カウントアップ
				score.Count_Up (1);				// スコアカウントアップ
				gamemain_sub.ObjInList (other.gameObject);// リストに格納
				gamemain_sub.CharMoveOrder ();// 新しいターゲットの選定								
			} else { 
				if (gamemain.ObjFlagC () == 2 && hit.GetNum () != 1) {
						gamemain_sub.SayonaraObj ();
				}
				charspeed_mgr.SpeedDown ();								
			}
		}

		if (input_bt.GreenTrigger ()) { 
			if (HitNum == 2) {							
				charspeed_mgr.CountUp ();		// 難易度設定カウントアップ
				score.Count_Up (1);				// スコアカウントアップ
				gamemain_sub.ObjInList (other.gameObject);// リストに格納
				gamemain_sub.CharMoveOrder ();// 新しいターゲットの選定
			} else {								
				if (gamemain.ObjFlagC () == 2 && hit.GetNum () != 2) {
						gamemain_sub.SayonaraObj ();
				}
				charspeed_mgr.SpeedDown ();							
			}
		}

		if (input_bt.BlueTrigger ()) { 
			if (HitNum == 3) {								
				charspeed_mgr.CountUp ();		// 難易度設定カウントアップ
				score.Count_Up (1);				// スコアカウントアップ
				gamemain_sub.ObjInList (other.gameObject);// リストに格納
				gamemain_sub.CharMoveOrder ();// 新しいターゲットの選定								
			} else {							
				if (gamemain.ObjFlagC () == 2 && hit.GetNum () != 3) {
						gamemain_sub.SayonaraObj ();
				}
				charspeed_mgr.SpeedDown ();								
			}
		}

		if (input_bt.YellowTrigger ()) { 
			if (HitNum == 4) {								
				charspeed_mgr.CountUp ();		// 難易度設定カウントアップ
				score.Count_Up (1);				// スコアカウントアップ
				gamemain_sub.ObjInList (other.gameObject);// リストに格納
				gamemain_sub.CharMoveOrder ();// 新しいターゲットの選定								
			} else {								
				if (gamemain.ObjFlagC () == 2 && hit.GetNum () != 4) {
						gamemain_sub.SayonaraObj ();
				}
				charspeed_mgr.SpeedDown ();
			}						
		}
	}

	// 何色に当たっているか
	public int GetNum(){
		return HitNum;
	}
}


