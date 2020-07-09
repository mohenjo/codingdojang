// Light More Light
package main

import "fmt"

// goMabu: 마지막 전구 상태 반환
func goMabu(num uint64) string {
	light := false
	var way uint64
	for way = 1; way <= num; way++ {
		if num%way == 0 {
			light = !light
		}
	}
	if light == false {
		return "no"
	} else {
		return "yes"
	}
}

func main() {
	var numLight uint64
	numLights := []uint64{}
	for {
		fmt.Scanln(&numLight)
		if numLight == 0 {
			break
		} else {
			numLights = append(numLights, numLight)
		}
	}
	for _, v := range numLights {
		fmt.Println(goMabu(v))
	}
}
