// Ones
package main

import (
	"fmt"
	"strconv"
)

func getMinOnes(num int) int {
	numStr := "1"
	for {
		if val, _ := strconv.Atoi(numStr); val%num == 0 {
			return len(numStr)
		} else {
			numStr += "1"
		}
	}
}

func main() {
	fmt.Println(getMinOnes(3))
	fmt.Println(getMinOnes(7))
	fmt.Println(getMinOnes(9901))
}
