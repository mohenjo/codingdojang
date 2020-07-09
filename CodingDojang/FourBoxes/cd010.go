/* Four Boxes */
package main

import "fmt"

var grid [1001][1001]bool

func main() {
	var x1, y1, x2, y2 int
	for line := 1; line <= 4; line++ {
		fmt.Scanf("%d %d %d %d\n", &x1, &y1, &x2, &y2)
		draw(x1, y1, x2, y2)
	}
	fmt.Println(area())
}

func draw(x1, y1, x2, y2 int) {
	for y := y1; y < y2; y++ {
		for x := x1; x < x2; x++ {
			grid[y][x] = true
		}
	}
}

func area() int {
	count := 0
	for y := 0; y <= 1000; y++ {
		for x := 0; x <= 1000; x++ {
			if grid[y][x] == true {
				count++
			}
		}
	}
	return count
}
