/* Primary Arithmetic */
package main

import (
	"fmt"
	"os"
	"strconv"
	"strings"
)

func main() {
	var (
		inp1, inp2 int
		msg        string
	)
	for {
		fmt.Scanf("%d %d\n", &inp1, &inp2)
		if inp1 == 0 && inp2 == 0 {
			fmt.Println(msg)
			os.Exit(0)
		}
		msg += (countCarry(inp1, inp2) + "\n")
	}
}

func num2array(num int) [10]int {
	var rst [10]int
	for idx, val := range strings.Split(fmt.Sprintf("%10d", num), "") {
		rst[idx], _ = strconv.Atoi(val)
	}
	return rst
}

func countCarry(n1, n2 int) string {
	num1, num2 := num2array(n1), num2array(n2)
	count, carry := 0, 0
	for idx := len(num1) - 1; idx > 0; idx-- {
		if num1[idx]+num2[idx]+carry >= 10 {
			carry = 1
			count++
		} else {
			carry = 0
		}
	}
	var msg string
	if count > 0 {
		msg = strconv.Itoa(count) + " carry operations."
	} else {
		msg = "No carry operations."
	}
	return msg
}
