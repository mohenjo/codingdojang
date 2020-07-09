// golang 1.9
package main

import (
	"fmt"
	"math"
)

func main() {
	inp := [][2]int{
		{0, 1}, {1, 1}, {2, 1}, {1, 10}, {10, 10}, {11, 10},
	} // (m, n) 슬라이스

	for i := 0; i < len(inp); i++ {
		// ceiling 함수 사용
		pageNum := math.Ceil(float64(inp[i][0]) / float64(inp[i][1]))
		fmt.Printf("(%d, %d) > %v\n", inp[i][0], inp[i][1], pageNum)
	}
}
