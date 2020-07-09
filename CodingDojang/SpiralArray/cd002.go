/* Spiral Array */
package main

import "fmt"

func main() {
	var maxX, maxY int
	fmt.Print("Input matrix size y, x separated by space: ")
	n, err := fmt.Scanf("%d %d", &maxX, &maxY)
	if err != nil || n != 2 {
		panic("Invalid input")
	}

	mat := newMatrix(maxX, maxY)
	for i := 1; i < maxX*maxY; i++ {
		mat.put2next(i)
	}
	mat.printMaxtix()
}

// matrix struct
type matrix struct {
	maxx, maxy int
	dx, dy     int
	posx, posy int
	value      [][]int
}

// newMatrix: matrix struct constructor
func newMatrix(maxx, maxy int) *matrix {
	m := matrix{}
	m.maxx, m.maxy = maxx, maxy
	m.posx, m.posy, m.dx, m.dy = 0, 0, 1, 0
	m.value = make([][]int, maxy)
	for y := 0; y < maxy; y++ {
		m.value[y] = make([]int, maxx)
		for x := 0; x < maxx; x++ {
			m.value[y][x] = -1
		}
	}
	m.value[0][0] = 0
	return &m
}

// nextDirection: 매트릭스 내 입력 방향(x, y 방향 증가분) 설정
func (m *matrix) nextDirection() {
	switch {
	case m.dx == 1 && m.dy == 0:
		m.dx, m.dy = 0, 1
	case m.dx == 0 && m.dy == 1:
		m.dx, m.dy = -1, 0
	case m.dx == -1 && m.dy == 0:
		m.dx, m.dy = 0, -1
	case m.dx == 0 && m.dy == -1:
		m.dx, m.dy = 1, 0
	}
}

// put2next: 구조체 범위 내, 값이 없는 부분에 인수 값 입력
func (m *matrix) put2next(inputValue int) { // start pos = (1, 0)
	tmpx, tmpy := m.posx+m.dx, m.posy+m.dy
	if tmpx < 0 || tmpx >= m.maxx || tmpy < 0 || tmpy >= m.maxy {
		m.nextDirection()
	} else if m.value[tmpy][tmpx] >= 0 {
		m.nextDirection()
	}
	m.posx += m.dx
	m.posy += m.dy
	m.value[m.posy][m.posx] = inputValue
}

// printMatrix: print matrix struct
func (m *matrix) printMaxtix() {
	for y := 0; y < len(m.value); y++ {
		for x := 0; x < len(m.value[y]); x++ {
			fmt.Printf("%3d ", m.value[y][x])
		}
		fmt.Println()
	}
}
