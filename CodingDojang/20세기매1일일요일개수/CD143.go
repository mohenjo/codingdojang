// golang 1.9
package main

import (
    "fmt"
    "time"
)

func main() {
    stime := time.Date(1900, time.January, 1, 0, 0, 0, 0, time.UTC)
    etime := time.Date(1999, time.December, 31, 0, 0, 0, 0, time.UTC)

    // 1990.1.1->1999.12.31 1day 증가하며 매월 1일 && "Sunday"인 경우 카운트
    count := 0
    for !(stime == etime) {
        if stime.Day() == 1 && stime.Weekday().String() == "Sunday" {
            count++
        }
        stime = stime.AddDate(0, 0, 1)
    }
    fmt.Println(count)
}

// ans: 172
