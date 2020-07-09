// 탭을 공백 문자로 바꾸기
package main

import (
	"os"
	"strings"
)

func main() {
	// 특정 파일 명에 대해 Tab2Spaces 호출 실행
	// ...
}

func Tab2Spaces(filename string) {
	ifile, _ := os.Open(filename)
	defer ifile.Close()

	stat, _ := ifile.Stat()
	bs := make([]byte, stat.Size())
	ifile.Read(bs)
	str := string(bs)
	newstr := strings.Replace(str, "\t", "    ", -1)

	ofile, _ := os.Create(filename + "-tab2spaced.txt")
	defer ofile.Close()
	ofile.WriteString(newstr)
}
