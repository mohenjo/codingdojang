/* 앞뒤가 같은 수 */
package main

import (
	"fmt"
	"strconv"
)

func main() {
	fmt.Println(nthPalindrome(1))
	fmt.Println(nthPalindrome(4))
	fmt.Println(nthPalindrome(30))
	fmt.Println(nthPalindrome(100))
	fmt.Println(nthPalindrome(30000))
	fmt.Println(nthPalindrome(10000000))
}

// nthPalindrome: nth번째 Palindrome 값 반환
func nthPalindrome(nth int) int {
	// n이 몇 번째(nDigits) Palindrome 슬라이스에 해당되는 지 계산
	nDigits, count := 1, len(Palindrome(1))
	for nth > count {
		nDigits++
		count += len(Palindrome(nDigits))
	}
	// nDigits-1 번째 Palindrome 까지 개수 카운트
	count = 0
	for i := 1; i < nDigits; i++ {
		count += len(Palindrome(i))
	}
	// nDigits번째 Palindrome 슬라이스에서 nth에 매칭되는 값 반환
	rst, _ := strconv.Atoi(Palindrome(nDigits)[(nth-count)-1])
	return rst
}

// Palindrome: nDigits 자리수의 Palindrome 슬라이스 반환(재귀사용)
func Palindrome(nDigits int) []string {
	rst := []string{}
	switch {
	case nDigits == 1:
		for i := 0; i < 10; i++ {
			rst = append(rst, fmt.Sprint(i))
		}
	case nDigits%2 == 0:
		for _, ve := range Palindrome(nDigits - 1) {
			if ve[0:1] != "0" {
				half := int(len(ve)/2 + 1)
				rst = append(rst, ve[:half]+reverse(ve[:half]))
			}
		}
	case nDigits%2 != 0:
		for _, ve := range Palindrome(nDigits - 1) {
			for _, v1 := range Palindrome(1) {
				half := len(ve) / 2
				rst = append(rst, ve[:half]+v1+ve[half:])
			}
		}

	}
	return rst
}

func reverse(s string) string {
	rst := ""
	for idx := 0; idx < len(s); idx++ {
		rst = s[idx:idx+1] + rst
	}
	return rst
}
