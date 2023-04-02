---
title:  "[Memo-Unity] 1. 재화 축약 표현 (K,M ,~~)"
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [Unity, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-03-26

---
- - -
재화 축약 표현

[고박사의 유니티 기초](https://www.inflearn.com/course/%EA%B3%A0%EB%B0%95%EC%82%AC-%EC%9C%A0%EB%8B%88%ED%8B%B0-%EA%B8%B0%EC%B4%88/dashboard)를 정리. 
{: .notice--info}


# 재화

킬로 (K) : 10의 3승 1 000  
메가 (M) : 10의 6승 1 000 000  
기가 (G) : 10의 9승 1 000 000 000  
T(12) - P(15) - E - Z - Y  

<br><br>

---
#   NotateNumber.cs

<div class="notice--primary" markdown="1"> 

`NotateNumber.cs`
  ```c# 
public class NotateNumber
{
    public static String Transform(long originNumber)
    {
       string[] symbol = new string[7]{ "K" , "M" ,"G" ,"T" ,"P" ,"E" ,"Z" ,};
       
       //매개변수로 받아온 숫자를 문자열로 변환
       string result = originNumber.ToString();

       //숫자+심볼은 최대 4자리까지만 표기, 숫자가 4자리 이하면 그냥출력
       if ( result.Length < 4 ){
        return result;
       }
       for(int i = 0; i< symbol.Length; ++i){
            if( 4 + 3 * i <= result.Length && result.Length < 4 + 3 * ( i + 1 )){
                // 3으로 나눴기 때문에 나머지 값은 0,1,2
                int n = result.Length % 3;
                // 나머지 값(n)이 0이면 3으로 설정
                n = n == 0 ? 3 : n;
                // 나머지 값 개수 (n) = 앞자리 개수
                // result.Substring(0,n) 0~n 앞자리 표시
                // result.Substring(n,1) 소숫점 한자리 표시 
                result = $"{result.Substring(0,n)}.{result.Substring(n,1)}";
                //축약 기호 추가
                result += symbol[i];
                break;
            }
       }
    }
}
  ```
-   K, M , G ,T ,P ,E ,Z 축약 표시
-   
</div>

# GoldManager-GPT에 물어본 코드
<div class="notice--primary" markdown="1"> 

`GoldManager.cs`
  ```c# 
public class GoldManager : MonoBehaviour
{
    private int goldAmount = 5000; // 골드 재화의 초기 값

    public void AbbreviateGold()
    {
        if (goldAmount >= 1000)
        {
            string abbreviatedGold = string.Empty;
            float abbreviatedValue = goldAmount;

            if (goldAmount >= 1000 && goldAmount < 1000000)
            {
                abbreviatedValue = goldAmount / 1000f;
                abbreviatedGold = "K";
            }
            else if (goldAmount >= 1000000 && goldAmount < 1000000000)
            {
                abbreviatedValue = goldAmount / 1000000f;
                abbreviatedGold = "M";
            }
            else if (goldAmount >= 1000000000)
            {
                abbreviatedValue = goldAmount / 1000000000f;
                abbreviatedGold = "B";
            }

            goldAmount = Mathf.FloorToInt(abbreviatedValue);
            Debug.Log("골드 축약: " + goldAmount + abbreviatedGold);
        }
        else
        {
            Debug.Log("골드 축약 불가: 최소 값인 1000 이상이어야 합니다.");
        }
    }
}
  ```
-   chat-gpt 코드
</div>



<br><br>

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
