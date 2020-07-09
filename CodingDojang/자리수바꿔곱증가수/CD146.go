// golang 1.9
package main

import (
    "fmt"
    "strconv"
)

func main() {

    count := 0
    for i3 := 1; i3 <= 9; i3++ {
        for i2 := 0; i2 <= 9; i2++ {
            for i1 := 1; i1 <= 9; i1++ {
                numStr := fmt.Sprintf("%d%d%d", i3, i2, i1) // 마지막 자리가 0이 아닌 3자리 자연수 문자열 생성
                numRev := rev(numStr)                       // 역 숫자(로된) 문자열
                numX, _ := strconv.Atoi(numStr)
                numR, _ := strconv.Atoi(numRev)
                if incChk(numX * numR) {
                    count++
                }
            }
        }
    }
    fmt.Println(count)
}

// 숫자(로된) 문자열의 역 숫자(로된) 문자열 반환
func rev(s string) string {
    retStr := ""
    for i := 0; i < len(s); i++ {
        retStr = s[i:i+1] + retStr
    }
    return retStr
}

// 숫자가 증가수인지 체크
func incChk(n int) bool {
    var chk bool = true
    s := fmt.Sprintf("%d", n) // 숫자의 문자열에 대해
    for i := 0; i < len(s)-1; i++ {
        nf, _ := strconv.Atoi(s[i : i+1])   // i 자리
        nb, _ := strconv.Atoi(s[i+1 : i+2]) // i+1 자리
        if nf > nb {                        // 증가 여부 체크
            chk = false
        }
    }
    return chk
}

// ans: 21