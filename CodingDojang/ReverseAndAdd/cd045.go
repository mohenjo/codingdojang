// Reverse And Add
package main

import (
	"fmt"
	"strconv"
)

func getPalindrome(anInteger uint64) uint64 { // get the palindrome number of anInteger
	iString := fmt.Sprint(anInteger)
	oString := ""
	for _, v := range iString {
		oString = string(v) + oString
	}
	rst, _ := strconv.ParseUint(oString, 10, 64)
	return rst
}

func getNext(anInteger uint64) uint64 { // return anInteger + Palindrome(anInteger)
	return anInteger + getPalindrome(anInteger)
}

func isPalindrome(anInteger uint64) bool { // check if anInteger is a palindrome number
	return anInteger == getPalindrome(anInteger)
}

func getCount(anInteger uint64) (int, uint64) { // return the reverse-counts and the palindrome number
	count := 0
	chk := anInteger
	for {
		if isPalindrome(chk) {
			return count, chk
		} else {
			chk = getNext(chk)
			count++
		}
	}
}

func main() {
	var try int
	fmt.Scanln(&try)
	integers := make([]int, try)
	for i := 0; i < try; i++ {
		fmt.Scanln(&integers[i])
	}
	for _, v := range integers {
		fmt.Println(getCount(uint64(v)))
	}
}
