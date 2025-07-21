---
title:  "[Unity] 문자열, 배열 - ^기호(뒤에서 인덱싱) , ..기호(범위)"
excerpt: ""

categories:
    - Til
tags:
    - [C#, TIL]

toc: true
toc_sticky: true
 
date: 2025-07-09 05:00

---
- - -


<br>
- - - 


# ^ 기호  
뒤에서부터 인덱싱  
^n은 Length - n과 같다.  
`str[^1]` = str[str.Length - 1]  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

<details>
<summary>^ 기호 인덱싱</summary>
<div class="notice--primary" markdown="1"> 

```c# 
string S = ABCDE;
// S[^1] = 'E' 뒤에서 1번째
// S[^2] = 'D' 뒤에서 2번째

int[] nums = { 10, 20, 30, 40, 50 };
int last = nums[^1];        // 50
```
</div>
</details>

<br><br><br>
- - - 

# ..기호 - 범위(슬라이스)
범위를 나타냄  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

<details>
<summary>..기호 범위</summary>
<div class="notice--primary" markdown="1"> 

```c# 
string S = ABCDE;
// S[1..3] = 'BCD' 인덱스 1 ~ 3
// S[..3] = 'ABC' 처음부터 3
// S[2] = 'CDE' 2부터 끝까지
// S[..^1] = 'ABCD' 처음부터 뒤에서 1번째 전까지
// S[^3..^1] = 'CD' 뒤에서 3번째에서 1번째  전까지

int[] nums = { 10, 20, 30, 40, 50 };
var firstThree = nums[..3]; // {10, 20, 30}
```
</div>
</details>


<br><br><br><br><br>
- - - 


# 메모
`^`기호, `..`기호 사용하기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -