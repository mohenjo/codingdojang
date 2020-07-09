// golang 1.10
package main

import (
	"fmt"
	"strconv"
)

func main() {
	// mapping the generated
	dned := make(map[int]int)
	for i := 1; i <= 5000; i++ {
		dned[d(i)] += 1
	}
	// sum self numbers
	var sum int = 0
	for i := 1; i < 5000; i++ {
		if _, exist := dned[i]; !exist {
			sum += i
		}
	}
	fmt.Println(sum)
}

// calculate generated number, d(n)
func d(n int) int {
	nstr := strconv.Itoa(n)
	var calc int = n
	for i := 0; i < len(nstr); i++ {
		cnvVal, _ := strconv.Atoi(nstr[i : i+1])
		calc += cnvVal
	}
	return calc
}

// ans: 1227365
