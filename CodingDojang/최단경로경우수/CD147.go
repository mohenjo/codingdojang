// golang 1.9
package main

import (
    "fmt"
    "math"
)

func main() {
    matrix := [][]string{
        {"A", "0", "0", "0"},
        {"0", "0", "0", "0"},
        {"0", "0", "S", "0"},
        {"0", "0", "0", "B"},
    }
    // matrx 내에서 A, S, B 위치 파악
    var ax, ay, sx, sy, bx, by float64
    for y := 0; y < len(matrix); y++ {
        for x := 0; x < len(matrix[y]); x++ {
            peekStr := matrix[y][x]
            switch peekStr {
            case "A":
                ax = float64(x)
                ay = float64(y)
            case "S":
                sx = float64(x)
                sy = float64(y)
            case "B":
                bx = float64(x)
                by = float64(y)
            }
        }
    }

    // 경로 수 구하는 함수
    // 동일한 것이 각각 p, q, r개로 이루어진 N개의 집합을 순서대로 나열하는 경우의 수는
    // N! / (p! * q! * r! * ...) where p+q+r+... = N
    // 이 문제의 경우 (x거리+y거리)! / {(x거리)!*(y거리)!}
    cases := func(dx float64, dy float64) float64 {
        return fact(dx+dy) / (fact(dx) * fact(dy))
    }

    // 경로 수 = (A->S 경로 수) * (S->B 경로 수)
    routes := cases(math.Abs(sx-ax), math.Abs(sy-ay)) *
        cases(math.Abs(bx-sx), math.Abs(by-sy))
    // 결과 출럭
    fmt.Println(routes)
}

// fact function
func fact(arg float64) float64 {
    if arg == 0 {
        return 1
    } else {
        return arg * fact(arg-1)
    }
}

// ans: 12
