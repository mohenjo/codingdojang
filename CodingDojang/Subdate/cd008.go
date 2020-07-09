/* Subdate */
package main

import (
	"fmt"
	"math"
)

func main() {

	fmt.Println(subDate(20070515, 20070501))
	fmt.Println(subDate(20070301, 20070515))

}

func isYun(year int) bool {
	rst := false
	if (year%4 == 0 && year%100 != 0) || year%400 == 0 {
		rst = true
	}
	return rst
}

func daysInMonth(year int) []int {
	days := []int{0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31} // don't count days[0]
	if isYun(year) {
		days[2] = 29
	}
	return days
}

func daysInYear(year int) int {
	days := 0
	for m := 1; m <= 12; m++ {
		days += daysInMonth(year)[m]
	}
	return days
}

func daysFromOrigin(year, month, day int) int {
	days := day
	for m := 1; m < month; m++ {
		days += daysInMonth(year)[m]
	}
	for y := 1582; y < year; y++ { // Gregorian calendar starts in 1582
		days += daysInYear(y)
	}
	return days
}

func parseDate(date int) (year, month, day int) {
	datestr := fmt.Sprint(date)
	n, err := fmt.Sscanf(datestr, "%4d%2d%2d", &year, &month, &day)
	if n != 3 || err != nil {
		panic("Invalid date string")
	}
	return
}

func subDate(date1, date2 int) int {
	y1, m1, d1 := parseDate(date1)
	y2, m2, d2 := parseDate(date2)
	sub := math.Abs(float64(daysFromOrigin(y1, m1, d1) - daysFromOrigin(y2, m2, d2)))
	return int(sub)
}
