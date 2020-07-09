// 3n+1 Problem
package main

import (
	"fmt"
)

func main() {
	var start, end int
	fmt.Scanf("%d %d", &start, &end)
	var maxCycle int
	for i := start; i <= end; i++ {
		if val := cycleLen(i); val > maxCycle {
			maxCycle = val
		}
	}
	fmt.Println(maxCycle)
}

func cycleLen(n int) int {
	rst := []int{n}
	seq := n
	for seq != 1 {
		if seq%2 == 0 {
			seq /= 2
		} else {
			seq = 3*seq + 1
		}
		rst = append(rst, seq)
	}
	return len(rst)
}
