using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UguiElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] Sprite normalImg; // 기본 백그라운드 img
	[SerializeField] Sprite hoverImg; // 버튼 위에 마우스를 올려놓을 때 백그라운드 img
	[SerializeField] Sprite activeImg; // 버튼을 클릭할 때 백그라운드 img

	
	enum eHandType { START, PAR, GOO, CHOKI };
	[SerializeField] eHandType handType; // 플레이어가 내는 손모양

	Button btn;
	GameObject unityChan;
	JankenUGUI janken;

	private void Start()
	{
		btn = GetComponent<Button>();
		unityChan = GameObject.Find("unitychan");
		janken = unityChan.GetComponent<JankenUGUI>();

		btn.image.sprite = normalImg;
	}

	private void Update()
	{
		if (!janken.flagJanken)
		{
			InitialJankenUI();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		btn.image.sprite = hoverImg;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		btn.image.sprite = normalImg;
	}

	public void ChangeImgOnClick()
	{
		btn.image.sprite = activeImg;
	}

	public void PlayerHand()
	{
		switch (handType)
		{
			case eHandType.START:
				janken.flagJanken = true;
				break;
			case eHandType.GOO:
				janken.myHand = 0;
				janken.modeJanken++;
				break;
			case eHandType.CHOKI:
				janken.myHand = 1;
				janken.modeJanken++;
				break;
			case eHandType.PAR:
				janken.myHand = 2;
				janken.modeJanken++;
				break;
			default:
				break;
		}
	}

	void InitialJankenUI()
	{
		switch (handType)
		{
			case eHandType.START:
				btn.image.enabled = true;
				btn.enabled = true;
				break;
			case eHandType.GOO:
				btn.image.sprite = normalImg;
				gameObject.SetActive(false);
				break;
			case eHandType.CHOKI:
				btn.image.sprite = normalImg;
				gameObject.SetActive(false);
				break;
			case eHandType.PAR:
				btn.image.sprite = normalImg;
				gameObject.SetActive(false);
				break;
			default:
				break;
		}
	}

}
