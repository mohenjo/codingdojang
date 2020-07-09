// Jolly Jumpers
package main

import (
	"bufio"
	"fmt"
	"math"
	"os"
	"reflect"
	"sort"
	"strconv"
	"strings"
)

// getDiffSlice: 슬라이스 멤버의 숫자 차이로 구성된 슬라이스(sorted) 반환
func getDiffSlice(iSlice []int) []int {
	rst := []int{}
	for i := 0; i < len(iSlice)-1; i++ {
		rst = append(rst, int(math.Abs(float64(iSlice[i]-iSlice[i+1]))))
	}
	sort.Ints(rst)
	return rst
}

// isJolly: if aSlice == range [1..num) -> "Jolly" else "Not Jolly"
func isJolly(aSlice []int, num int) string {
	cmpSlice := []int{}
	for i := 1; i < num; i++ {
		cmpSlice = append(cmpSlice, i)
	}
	rst := "Not Jolly"
	if reflect.DeepEqual(aSlice, cmpSlice) {
		rst = "Jolly"
	}
	return rst
}

// parseInput
func parseInput() string {
	var iString, rst string
	for {
		// read a string line
		reader := bufio.NewReader(os.Stdin)
		iString, _ = reader.ReadString('\n')
		iString = strings.TrimSpace(iString)
		// split the string to a slice
		tmp := strings.Split(iString, " ")
		num, _ := strconv.Atoi(tmp[0])
		if num == 0 {
			break
		}
		aSlice := []int{}
		for _, v := range tmp[1:] {
			v2i, _ := strconv.Atoi(v)
			aSlice = append(aSlice, v2i)
		}
		// check if Jolly Jumber
		rst = rst + isJolly(getDiffSlice(aSlice), num) + "\n"
	}
	return rst
}

func main() {
	fmt.Println(parseInput())
}
