// golang 1.9
package main

import (
    "fmt"
    "math"
)

func main() {
    pVal := 3 // 자리수

    var maxMult int = 0 // 최대 대칭수
    for i := math.Pow10(pVal - 1); i < math.Pow10(pVal); i++ {
        for j := math.Pow10(pVal - 1); j < math.Pow10(pVal); j++ {
            calc := int(i * j)
            chkStr := fmt.Sprintf("%d", calc)
            if chkStr == rev(chkStr) && calc > maxMult { // 대칭 and 최대값
                maxMult = calc
            }
        }
    }
    fmt.Println(maxMult)
}

// reverse string
func rev(s string) string {
    retStr := ""
    for i := 0; i < len(s); i++ {
        retStr = s[i:i+1] + retStr
    }
    return retStr
}

// ans: 906609
