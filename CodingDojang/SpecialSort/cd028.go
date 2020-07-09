// Special Sort
package main

import (
	"fmt"
)

func main() {
	var input []int
	input = []int{-1, 1, 3, -2, 2}
	rstNeg, rstPos := []int{}, []int{}
	for _, v := range input {
		if v < 0 {
			rstNeg = append(rstNeg, v)
		} else {
			rstPos = append(rstPos, v)
		}
	}
	rst := []int{}
	rst = append(rst, rstNeg...)
	rst = append(rst, rstPos...)
	fmt.Println(rst)
}
