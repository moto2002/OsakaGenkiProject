﻿using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

	//入力
	InputMg	   input_bt;
	GameObject go;

	// コンポーネント用
	GameMain 		gamemain;
	GameMain_sub	gamemain_sub;
	CharSpeedMgr	charspeed_mgr;
	Hit_sub			hit_sub;
	Score			score;

	// ヒットしている色
	int HitNum = 0;

	// Use this for initialization
	void Start () {

		// コンポーネントをゲット
		gamemain = GameObject.Find ("Pare").GetComponent<GameMain> ();
		gamemain_sub = GameObject.Find ("Pare").GetComponent<GameMain_sub> ();
		hit_sub = GameObject.Find ("Spot_R").GetComponent<Hit_sub> ();
		input_bt = GameObject.Find ("InputMane").GetComponent<InputMg> ();
		charspeed_mgr = GameObject.Find ("Speed_Mgr").GetComponent<CharSpeedMgr> ();
		score = GameObject.Find ("Score_name").GetComponent<Score> ();

	}
	
	// Update is called once per frame
	void Update () {
		// 当たっていないときにボタンを押すと飛ぶ
		if (input_bt.AnyTrigger()) {
			if (gamemain.ObjFlagC () == 0 && gamemain_sub.ObjFlagC () == 0 && 
			    GameObject.Find ("SayonaraLine").transform.position.x < this.transform.position.x) {
				gamemain.SayonaraObj();
				//charspeed_mgr.SpeedDown();
			}
		}
	}

	private void OnTriggerEnter(Collider other){
		HitNum = 0;
		// フラグを立てる
		gamemain.ObjHitOn ();

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

	// ボタンを押したときの処理(間違っていたら速攻で飛ばす)
	private void OnTriggerStay(Collider other)
	{
		//Debug.Log(other.gameObject.renderer.material.name);
		if (input_bt.RedTrigger ()) { 
			if (HitNum == 1) {
					charspeed_mgr.CountUp ();		// 難易度設定カウントアップ
					score.Count_Up (1);				// スコアカウントアップ
					gamemain.ObjInList (other.gameObject);// リストに格納
					gamemain.CharMoveOrder ();// 新しいターゲットの選定					
			} else {						
				if (gamemain_sub.ObjFlagC () == 2 && hit_sub.GetNum () != 1) {
						gamemain.SayonaraObj ();
				}
				charspeed_mgr.SpeedDown ();							
			}
		}

		if (input_bt.GreenTrigger ()) { 
			if (HitNum == 2) {										
					charspeed_mgr.CountUp ();		// 難易度設定カウントアップ
					score.Count_Up (1);				// スコアカウントアップ
					gamemain.ObjInList (other.gameObject);// リストに格納
					gamemain.CharMoveOrder ();// 新しいターゲットの選定					
			} else {								
				if (gamemain_sub.ObjFlagC () == 2 && hit_sub.GetNum () != 2) {
						gamemain.SayonaraObj ();
				}
				charspeed_mgr.SpeedDown ();								
			}
		}

		if (input_bt.BlueTrigger ()) { 
			if (HitNum == 3) {
					charspeed_mgr.CountUp ();		// 難易度設定カウントアップ
					score.Count_Up (1);				// スコアカウントアップ
					gamemain.ObjInList (other.gameObject);// リストに格納
					gamemain.CharMoveOrder ();// 新しいターゲットの選定								
			} else {								
				if (gamemain_sub.ObjFlagC () == 2 && hit_sub.GetNum () != 3) {
						gamemain.SayonaraObj ();
				}
				charspeed_mgr.SpeedDown ();								
			}
		}

		if (input_bt.YellowTrigger ()) { 
			if (HitNum == 4) {
					charspeed_mgr.CountUp ();		// 難易度設定カウントアップ
					score.Count_Up (1);				// スコアカウントアップ
					gamemain.ObjInList (other.gameObject);// リストに格納
					gamemain.CharMoveOrder ();// 新しいターゲットの選定								
			} else {
				if (gamemain_sub.ObjFlagC () == 2 && hit_sub.GetNum () != 4) {
						gamemain.SayonaraObj ();
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
