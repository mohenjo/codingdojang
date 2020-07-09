// 단위 변환
package main

import (
	"fmt"
	"os"
)

var units map[string]float64

func initializeUnits() {
	units = make(map[string]float64)
	units["inch"] = 1.
	units["cm"] = units["inch"] / 2.54
	units["mm"] = units["cm"] / 10.
	units["pt"] = units["inch"] / 72.
	units["px"] = units["inch"] / 96.
	units["dxa"] = units["pt"] / 20.
	units["emu"] = units["dxa"] / 635.

}

func main() {
	initializeUnits()
	var factor float64
	var from, to string
	for {
		factor = 0
		fmt.Print("Input parameter1 [ex: 10 cm]: ")
		fmt.Scanf("%f %s\n", &factor, &from)
		if factor == 0 {
			os.Exit(0)
		}
		fmt.Print("Input parameter2 [ex: mm]: ")
		fmt.Scanf("%s\n", &to)
		rst := cnv(factor, from, to)
		fmt.Println(rst)
	}
}

func cnv(factor float64, from, to string) string {
	return fmt.Sprint(factor*units[from]/units[to]) + " " + to
}
