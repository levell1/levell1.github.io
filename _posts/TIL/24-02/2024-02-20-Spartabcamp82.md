---
title:  "[TIL] 82 CSV ,ProFiler⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-02-20 02:00

---
- - -

`CSV`, `ProFiler`

<BR><BR>

<center><H1>  최종 팀 프로젝트 24일차  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53  
&nbsp;&nbsp; [o] 면접 문제 풀기 - 5     
&nbsp;&nbsp; [o] 1,2반 마무리정리  챌~   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.   
&nbsp;&nbsp; [x] 디자인 코드 패턴 이해,정리하기.   
&nbsp;&nbsp; [x] 자료구조 디자인패턴 강의 다시 듣기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 간단한 CSV 불러오기
로딩씬 TIP 부분에 쓰기위한 CSV사용 , 불러오기  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/e8d1dd6d-2ca1-4750-96e9-459c41fca5c7)  
[CSVReader 스크립트 참조](https://bravenewmethod.com/2014/09/13/lightweight-csv-reader-for-unity/#comment-7111)  

**CSVReader.cs**  
<div class="notice--primary" markdown="1"> 

```c# 
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    public static List<Dictionary<string, object>> Read(string file)
    {
        var list = new List<Dictionary<string, object>>();
        TextAsset data = Resources.Load(file) as TextAsset;

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1) return list;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {

            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            var entry = new Dictionary<string, object>();
            for (var j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value;
                int n;
                float f;
                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry);
        }
        return list;
    }
}

불러오기
List<Dictionary<string, object>> data_Dialog = CSVReader.Read("CSV/Tip");
_randomIndex = Random.Range(0, data_Dialog.Count);
_tipText.text = (data_Dialog[_randomIndex]["Tip"].ToString());


```
</div>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/c5bda97d-1ae3-407c-a9ee-9ebe937d1305)  

불러오기는 된다. 다음에 더 많은데이터나 대화형식의 데이터를 사용할때 좀 더 공부.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 프로파일러(ProFiler)

똑같은 metarial -> enable gpuinstance 같은 matarial을 한번에 드로우콜로 넘긴다.
왼쪽에 체크해서 해당 내역을 볼 수 있다.   
하단좌측 timeline, hierarchy  
최적화 할 요소 찾기.  
핵심 gfx waitforpresent~~~ -> gpu 가 기다리고 있다 -> 렌더링 최적화 필요  
핵심 gfx waitforcommand~~~ -> cpu가 바빠서 명령을 기다리고있다 -> cpu최적화 해야된다  
세부적으로 볼려면  
상단에 deep profile 활성화  
하단우측 에 체크 다 하기    
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

마커 using.profiling  
public static readonly profilermarker mymarker = new profilemarker("mymarker");  
mymarker.begin ~ mymarker.end 까지의를 체크할 수 있다.  
빌드에서 development build-> auto profiler 체크 시 에디터 빼고 프로파일 가능.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 


# 잡담,정리

{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
