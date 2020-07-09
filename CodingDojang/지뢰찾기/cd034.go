// 지뢰찾기
package main

import (
	"fmt"
	"strings"
)

// mat: 매트릭스의 크기, 입력텍스트, 위치별 지뢰 갯수를 인스턴스 변수로 가진 객체 생
type mat struct {
	xMax, yMax int
	val        [][]string // 지뢰 텍스트
	count      [][]string // 인근 지뢰 갯수
}

// newMat: constructor
func newMat(xMax, yMax int, val [][]string) *mat {
	matrix := make([][]string, yMax)
	count := make([][]string, yMax)
	for y := 0; y < yMax; y++ {
		matrix[y] = make([]string, xMax)
		count[y] = make([]string, xMax)
		for x := 0; x < xMax; x++ {
			matrix[y][x] = val[y][x]
		}
	}
	m := mat{}
	m.xMax, m.yMax = xMax, yMax
	m.val = matrix
	m.count = count
	for y := 0; y < m.yMax; y++ {
		for x := 0; x < m.xMax; x++ {
			m.setPos(x, y)
		}
	}
	return &m
}

// setPos: 인근 지뢰 갯수 저장
func (m *mat) setPos(posx, posy int) {
	count := 0
	for y := posy - 1; y <= posy+1; y++ {
		if y < 0 || y >= m.yMax {
			continue
		}
		for x := posx - 1; x <= posx+1; x++ {
			if x < 0 || x >= m.xMax {
				continue
			}
			if m.val[y][x] == "*" {
				count++
			}
		}
	}
	if m.val[posy][posx] == "*" {
		m.count[posy][posx] = "*"
	} else {
		m.count[posy][posx] = fmt.Sprint(count)
	}
}

// solveMatrix: 결과 출력
func (m mat) solveMatrix() {
	for y := 0; y < m.yMax; y++ {
		for x := 0; x < m.xMax; x++ {
			fmt.Print(m.count[y][x], " ")
		}
		fmt.Println()
	}
}

// parsing
func parsing(aString string) (xMax, yMax int, inpMat [][]string) {
	tmp := strings.Split(aString, "\n")
	fmt.Sscanln(tmp[0], &xMax, &yMax)
	inpMat = make([][]string, yMax)
	for yidx, yval := range tmp[1:] {
		inpMat[yidx] = make([]string, xMax)
		for xidx, xval := range strings.Split(yval, "") {
			inpMat[yidx][xidx] = xval
		}
	}
	return
}

func main() {
	// 입력 예
	inpString := `4 4
*...
....
.*..
....`

	myNew := newMat(parsing(inpString))
	myNew.solveMatrix()
}

/* 출력
* 1 0 0
2 2 1 0
1 * 1 0
1 1 1 0
*/
