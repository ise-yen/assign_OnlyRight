using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateCheck : MonoBehaviour
{
    System.DateTime now;
    int nowMonth;
    int nowDay;

    private AudioSource univoice;
    public AudioClip voiceBirthday;

    public AudioClip[] voiceDate;
    public List<KeyValuePair<int, int>> eventDates = new List<KeyValuePair<int, int>>(); // 이벤트 날짜 모음 <int month, int day>

    void Start()
    {
        // 현재 날짜와 시간 얻기
        now = System.DateTime.Now;
        nowMonth = now.Month;
        nowDay = now.Day;

        //// 소리 재생

        // 음성 데이터 정리
        univoice = GetComponent<AudioSource>();

        FindEventDate();

        // 이전에 실행했던 날짜 얻기
        int oldMonth = PlayerPrefs.GetInt("Month");
        int oldDay = PlayerPrefs.GetInt("Day");
        Debug.Log("이전 실행일 : " + oldMonth + "월 " + oldDay + "일\n"
            + "현재 실행일 : " + nowMonth + "월 " + nowDay + "일");

        /// voiceDate에 담긴 AudioClip과 EVENT 날짜와 매칭시키기
		// 해당 음성이 있으면 재생
        for (int i = 0; i < eventDates.Count; i++)
        {
            // 이벤트 날짜 == 현실 날짜
            if (eventDates[i].Key == nowMonth && eventDates[i].Value == nowDay)
            {
                if(oldMonth != nowMonth || oldMonth != nowDay)
				{
					univoice.clip = voiceDate[i];
					univoice.Play();
                    Debug.Log(voiceDate[i].name);
                }
            }
        }


		// 현재 실행한 날짜 기록
		PlayerPrefs.SetInt("Month", nowMonth);
        PlayerPrefs.SetInt("Day", nowDay);


	}

	/// <summary>
	/// unityChan의 voiceList 중 EVENT 날짜를 TEXT 파일에서 자동으로 가져오기
	/// </summary>
	void FindEventDate()
	{
        // 1. txt파일 경로
        string filePath = Application.dataPath;
        filePath += "/UnityChan/Voice/unity-chan_voice_list.txt";

        // 2. txt파일 내용을 contents에 담음
        string[] contents = System.IO.File.ReadAllLines(filePath);

        // 3. contents가 있으면 月, 日用 찾아서 month와 day 값 가져오기
        if (contents.Length > 0)
        {
            // 이벤트날짜만 모음
            for (int i = 371; i < contents.Length - 1; i++)
            {
                int month = 0, day = 0;
                string str = contents[i];
                Debug.Log("i: " + str);

                int len = str.Length;
                day = (int)char.GetNumericValue(str[len - 3]); // 日用이전에 적힌 숫자 : day의 1의 자리

                // day가 2자리수
                if ((int)char.GetNumericValue(str[len - 4]) > 0 && (int)char.GetNumericValue(str[len - 4]) < 10)
                {
                    day += (int)char.GetNumericValue(str[len - 4]) * 10; // 10의 자리 추가

                    // str[len-5] == 月

                    month = (int)char.GetNumericValue(str[len - 6]); // 月 앞에 있는 숫자는 month의 1의 자리

                    // month가 2자리수
                    if ((int)char.GetNumericValue(str[len - 7]) > 0 && (int)char.GetNumericValue(str[len - 7]) < 3)
                    {
                        month += (int)char.GetNumericValue(str[len - 7]) * 10; // month의 10의 자리
                    }
                }
                // nowDay가 1자리수 == str[len-4]에 月이 들어있다는 의미
                else
                {
                    month = (int)char.GetNumericValue(str[len - 5]);

                    // month가 2자리수
                    if ((int)char.GetNumericValue(str[len - 6]) > 0 && (int)char.GetNumericValue(str[len - 6]) < 3)
                    {
                        month += (int)char.GetNumericValue(str[len - 6]) * 10; // nowMonth의 10의 자리
                    }
                }

                Debug.Log(month + "월 " + day + "일");
                // 이벤트 날짜들을 리스트에 넣기
                eventDates.Add(new KeyValuePair<int, int>(month, day));
            }
        }
        else Debug.Log("파일이 없습니다."); // contents가 없으면 로그 출력
    }
}

