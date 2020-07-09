// 그 시간 사무실에 몇 명이 있었나?
package main

import (
	"fmt"
	"strings"
)

func main() {
	log := `09:12:23 11:14:35
10:34:01 13:23:40
10:34:31 11:20:10`
	chkTime := "11:05:20"
	fmt.Println(CountIn(chkTime, log))
}

// parse & check log
func CountIn(chkTime, logTime string) int {
	count := 0
	var each []string
	for _, v := range strings.Split(logTime, "\n") {
		each = strings.Split(v, " ")
		if isIn(chkTime, each[0], each[1]) {
			count++
		}
	}
	return count
}

// check chkTime in [onTime..offTime]
func isIn(chkTime, onTime, offTime string) bool {
	chk := time2sec(chkTime)
	return time2sec(onTime) <= chk && chk <= time2sec(offTime)
}

// a String "hh:mm:ss" to an integer(seconds)
func time2sec(aString string) int {
	var hh, mm, ss int
	fmt.Sscanf(aString, "%2d:%2d:%2d", &hh, &mm, &ss)
	return ss + mm*60 + hh*60*60
}
