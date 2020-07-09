// golang 1.9
package main

import "fmt"

func main() {
    inpStr := "CATABCDEFGHIJKLMNOPQRSTUVWXYZ" // input string
    nMove := 5                                // 알파벳 이동량

    outStr := ""
    for _, v := range inpStr { // 문자열에 대해
        mvAmnt := int(v) + nMove // 아스키 값을 증가 이동
        if mvAmnt > 90 {
            mvAmnt = mvAmnt - 90 + 64 // Z를 넘어갈 경우 A로 순환
        }
        outStr += string(mvAmnt)
    }
    fmt.Println("String input : ", inpStr)
    fmt.Println("String output: ", outStr)

}

/* ans:
String input :  CATABCDEFGHIJKLMNOPQRSTUVWXYZ
String output:  HFYFGHIJKLMNOPQRSTUVWXYZABCDE
*/
