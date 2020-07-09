package main

import (
	"fmt"
	"strconv"
	"strings"
)

func v2s(aString string) []int { // version string to slice
	rst := []int{}
	for _, v := range strings.Split(aString, ".") {
		cnv, _ := strconv.Atoi(v)
		rst = append(rst, cnv)
	}
	return rst
}

func equalizeSliceLen(aSlice, bSlice []int) ([]int, []int) { // equalize lens of slices
	minLen, maxLen := len(aSlice), len(bSlice)
	minSlice, maxSlice := aSlice, bSlice
	swapd := false
	if minLen > len(bSlice) {
		minLen, maxLen = maxLen, minLen
		minSlice, maxSlice = maxSlice, minSlice
		swapd = true
	}
	for idx := 0; idx < maxLen-minLen; idx++ {
		minSlice = append(minSlice, 0)
	}
	if swapd {
		return maxSlice, minSlice
	} else {
		return minSlice, maxSlice
	}

}

func intCmp(l, r int) string {
	switch {
	case l > r:
		return ">"
	case l < r:
		return "<"
	default:
		return "="
	}
}

func sliceCmp(lSlice, rSlice []int) string { // return slices compare result
	lSliceNew, rSliceNew := equalizeSliceLen(lSlice, rSlice)
	end := len(lSliceNew)
	for i := 0; i < end; i++ {
		if cmp := intCmp(lSliceNew[i], rSliceNew[i]); cmp != "=" {
			return cmp
		} else {
			continue
		}
	}
	return "="
}

func VersionCompare(lstring, rstring string) string {
	return lstring + " " + sliceCmp(v2s(lstring), v2s(rstring)) + " " + rstring
}

func main() {
	var lver, rver string
	lver, rver = "0.0.2", "0.0.1"
	fmt.Println(VersionCompare(lver, rver))
	lver, rver = "1.0.10", "1.0.3"
	fmt.Println(VersionCompare(lver, rver))
	lver, rver = "1.2.0", "1.1.99"
	fmt.Println(VersionCompare(lver, rver))
	lver, rver = "1.1", "1.0.1"
	fmt.Println(VersionCompare(lver, rver))
}
