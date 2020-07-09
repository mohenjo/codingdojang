// 아마존 면접문제 중에
package main

import (
	"fmt"
)

func main() {
	var input []string
	input = []string{"a1", "a2", "a3", "a4", "a5", "b1", "b2", "b3", "b4", "b5"}
	fmt.Println(divideSlice(input))
}

func divideSlice(s []string) []string {
	l := len(s) / 2
	rst := []string{}
	for idx := 0; idx < l; idx++ {
		rst = append(rst, s[idx], s[l+idx])
	}
	return rst
}
