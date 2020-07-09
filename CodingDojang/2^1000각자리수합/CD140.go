// golang 1.9
package main

import (
    "fmt"
    "math"
    "strconv"
)

func main() {
    // sum digits function
    sum := func(s string) int {
        lsum := 0
        for i := 0; i < len(s); i++ {
            nsn, _ := strconv.Atoi(string(s[i]))
            lsum += nsn
        }
        return lsum
    }
    //
    fmt.Println(sum(fmt.Sprintf("%.f", math.Exp2(1000))))
}

// ans: 1366
