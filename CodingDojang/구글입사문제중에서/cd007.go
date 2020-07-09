// CD007 - 구글 입사문제 중에서
package main

import (
	"fmt"
	"strings"
)

func main() {
	count := 0
	for i := 1; i <= 10000; i++ {
		count += count8(fmt.Sprint(i))
	}
	fmt.Println(count)
}

// count "8"s in aString
func count8(aString string) int {
	count := strings.Count(aString, "8")
	return count
}
