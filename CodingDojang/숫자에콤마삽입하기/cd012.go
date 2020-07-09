/* 숫자에 콤마 삽입하기 */
package main

import (
	"fmt"
	"strconv"
	"strings"
)

func main() {
	var num1, num2, num3 float64 = 1000, 20000000, -3245.24
	fmt.Println(GetCurrency(num1))
	fmt.Println(GetCurrency(num2))
	fmt.Println(GetCurrency(num3))
}

func GetCurrency(num float64) string {
	numstr := strconv.FormatFloat(num, 'f', -1, 64)
	head, body, tail := parse(fmt.Sprint(numstr))
	body = commarize(body)
	return head + body + tail
}

func parse(num string) (head, body, tail string) {
	head, body, tail = "", num, ""
	if test := num[0:1]; test == "+" || test == "-" {
		head = test
		body = body[1:]
	}
	if chk := strings.Index(body, "."); chk != -1 {
		tail = body[chk:]
		body = body[:chk]
	}
	return
}

func commarize(body string) string {
	rst := ""
	for idx, txt := 0, reverse(body); idx < len(txt); idx++ {
		rst += txt[idx : idx+1]
		if idx%3 == 2 && idx != len(txt)-1 {
			rst += ","
		}
	}
	rst = reverse(rst)
	return rst
}

func reverse(s string) string {
	rst := ""
	for idx := 0; idx < len(s); idx++ {
		rst = s[idx:idx+1] + rst
	}
	return rst
}
