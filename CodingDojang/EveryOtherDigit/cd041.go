// Every Other Digit
package main

import (
	"fmt"
	"strconv"
)

// cnvt: aString의 짝수번째 문자가 숫자일 경우 *로 치
func cnvt(aString string) string {
	newString := ""
	for i, v := range aString {
		if _, err := strconv.Atoi(string(v)); i%2 == 1 && err == nil {
			newString += "*"
		} else {
			newString += string(v)
		}
	}
	return newString
}

func main() {
	inpString := "a1b2cde3~g45hi6"
	fmt.Println(cnvt(inpString))
}
