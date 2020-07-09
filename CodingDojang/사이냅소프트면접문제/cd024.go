// 사이냅소프트 면접문제
package main

import (
	"fmt"
	"sort"
	"strings"
)

var input = "이유덕,이재영,권종표,이재영,박민호,강상희,이재영,김지완,최승혁,이성연,박영서,박민호,전경헌,송정환,김재성,이유덕,전경헌"

func main() {
	inpStr := parser(input)
	// 김씨, 이씨 찾기
	var countKim, countLee int
	for _, v := range inpStr {
		if matchFamilyName(v, "김") {
			countKim++
		}
		if matchFamilyName(v, "이") {
			countLee++
		}
	}
	fmt.Printf("count 김: %d, 이: %d\n", countKim, countLee)
	// 이재영 찾기
	fmt.Printf("count 이재영: %d\n", countName(inpStr, "이재영"))
	// 중복제거
	rmd := removeDuplicate(inpStr)
	fmt.Println("중복제거: ", rmd)
	// 정렬
	fmt.Println("정렬: ", sortSlice(rmd))
}

func parser(s string) []string {
	return strings.Split(s, ",")
}

func matchFamilyName(s string, match string) bool {
	chk := false
	if string([]rune(s)[0]) == match {
		chk = true
	}
	return chk
}

func countName(s []string, match string) int {
	count := 0
	for _, v := range s {
		if v == match {
			count++
		}
	}
	return count
}

func removeDuplicate(s []string) []string {
	rst := []string{}
	set := map[string]bool{}
	for _, v := range s {
		set[v] = true
	}
	for key := range set {
		rst = append(rst, key)
	}
	return rst
}

func sortSlice(s []string) []string {
	sort.Strings(s)
	return s
}
