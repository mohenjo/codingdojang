/* LCD Display */
package main

import (
	"fmt"
	"os"
	"strconv"
	"strings"
)

var format map[int]string = map[int]string{
	0: "pbnbp", 1: "nrnrn", 2: "prplp", 3: "prprp", 4: "nbprn",
	5: "plprp", 6: "plpbp", 7: "prnrn", 8: "pbpbp", 9: "pbprp"}

func main() {
	var (
		inp1   int
		inp2   string
		scale  []int
		numstr []string
	)
	for {
		fmt.Print("Input [s]cale & [n]umber (ex. '3 12345' or '0 0' to quit): ")
		n, err := fmt.Scanf("%d %s\n", &inp1, &inp2)
		if n != 2 || err != nil {
			panic("Invalid input")
		}
		if inp1 == 0 && inp2 == "0" {
			for idx, _ := range scale {
				printNums(scale[idx], numstr[idx])
			}
			os.Exit(0)
		}
		scale = append(scale, inp1)
		numstr = append(numstr, inp2)
	}
}

// strgen generates string corrsponding [p]lain, [l]eft, [r]ight, [b]oth, [n]ull
func strgen(s string) string {
	rst := ""
	switch s {
	case "p":
		rst = " - "
	case "l":
		rst = "|  "
	case "r":
		rst = "  |"
	case "b":
		rst = "| |"
	case "n":
		rst = "   "
	}
	return rst
}

// lcd returns scaled lcd string as slice
func lcd(num, scale int) []string {
	var rst []string
	for idx := 0; idx < len(format[num]); idx++ {
		chk := strgen(format[num][idx : idx+1])
		genstr := chk[0:1] + strings.Repeat(chk[1:2], scale) + chk[2:3]
		if idx%2 == 0 {
			rst = append(rst, genstr)
		} else {
			for i := 0; i < scale; i++ {
				rst = append(rst, genstr)
			}
		}
	}
	return rst
}

// printNums display lcd numbers
func printNums(scale int, numstr string) {
	//  numstr := strconv.Itoa(nums)
	rst := make([]string, scale*2+3)
	for idx := 0; idx < len(numstr); idx++ {
		num, _ := strconv.Atoi(numstr[idx : idx+1])
		lcded := lcd(num, scale) // []string
		for i := 0; i < len(rst); i++ {
			rst[i] += (lcded[i] + " ")
		}
	}
	for idx := 0; idx < len(rst); idx++ {
		fmt.Println(rst[idx])
	}
}
