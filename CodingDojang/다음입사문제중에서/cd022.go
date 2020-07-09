// 다음 입사 문제 중에서
package main

import "fmt"

func main() {
	inp := []int{1, 3, 4, 8, 13, 17, 20}
	minIdx := 0
	minDst := inp[0]
	for i := 0; i < (len(inp) - 1); i++ {
		if chk := inp[i+1] - inp[i]; chk < minDst {
			minIdx = i
			minDst = chk
		}
	}
	fmt.Println(inp[minIdx], inp[minIdx+1])
}
