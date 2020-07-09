/* 리스트 회전 */
package main

import (
	"fmt"
	"strconv"
	"strings"
)

func main() {
	ex := []string{"1 10 20 30 40 50", "4 가 나 다 라 마 바 사", "-2 A B C D E F G", "0 똘기 떵이 호치 새초미"}
	for _, v := range ex {
		fmt.Println(rotate(parse(v)))
	}
}

func parse(inp string) (int, []string) {
	spltLst := strings.Split(inp, " ")
	count, _ := strconv.Atoi(spltLst[0])
	lst := spltLst[1:]
	return count, lst
}

func rotate(r int, lst []string) string {
	mov := r % len(lst)
	if mov < 0 {
		mov = len(lst) + mov
	}
	rst := append(lst[len(lst)-mov:], lst[:len(lst)-mov]...)
	return strings.Join(rst, " ")
}
