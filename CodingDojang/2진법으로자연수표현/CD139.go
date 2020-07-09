// golang 1.9
package main

import "fmt"

func main() {
    var inpNum int = 73
    fmt.Println(dec2bin(inpNum))
}

// 십진수 -> 이진수 변환
func dec2bin(dec int) string {
    bin := ""
    if dec >= 1 {
        bin = fmt.Sprintf("%d", dec%2) + bin
        bin = dec2bin(dec/2) + bin
    }
    return bin
}

// ans: 1001001
